/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.services;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import javax.annotation.Resource;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
import pl.polsl.lab.entities.Algorithms;
import pl.polsl.lab.entities.Numbers;
import pl.polsl.lab.entities.SortingTables;
import pl.polsl.lab.enums.Commands;
import pl.polsl.lab.exception.OutOfSupposedRangeException;
import pl.polsl.lab.model.SortModel;

/**
 * Sorting algorithms service class. It contains all operation that will be used
 * for communicating client with DB and sorting arrays.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
@WebService(serviceName = "SortingAlgorithmsService")
public class SortingAlgorithmsService {

    @PersistenceContext(unitName = "SortingAlgorithmsServicePU")
    private EntityManager em;
    @Resource
    private javax.transaction.UserTransaction utx;

    /**
     * Web service operation that adds a new sorting table, algorithm and
     * numbers to DB.
     *
     * @param size Size of an array.
     * @param algorithm Name of an algorithm.
     * @return Returns true if adding succeeded. False otherwise.
     */
    @WebMethod(operationName = "addSortingTable")
    public Boolean addSortingTable(@WebParam(name = "size") final int size, @WebParam(name = "algorithm") final String algorithm) {
        SortingTables newTable = new SortingTables();
        Algorithms newAlgorithm = new Algorithms();
        List<Numbers> newNumbers = new ArrayList<>();

        //setting numbers
        for (int i = 0; i < size; i++) {
            newNumbers.add(new Numbers(new Random().nextInt(size) + 1, i));
            newNumbers.get(i).setIsPointedAt(Boolean.FALSE);
            newNumbers.get(i).setTableId(newTable);
        }

        //setting algorithm
        if (algorithm.toUpperCase().equals("BUBBLE") || algorithm.toUpperCase().equals("BOGO") || algorithm.toUpperCase().equals("INSERTION")) {
            newAlgorithm.setName(algorithm.toLowerCase());

            newAlgorithm.setTableId(newTable);
            newAlgorithm.setState(1);

            //setting table
            newTable.setSize(size);
            newTable.setIsSorted(Boolean.FALSE);
            newTable.setAlgorithm(algorithm.toLowerCase());
            newTable.setNumbersList(newNumbers);

            //adding to DB
            try {
                persist(newTable, newAlgorithm, newNumbers);
            } catch (Exception exception) {
                System.err.println(exception.getMessage());
                return Boolean.FALSE;
            }

            return Boolean.TRUE;
        } else {
            return Boolean.FALSE;
        }
    }

    /**
     * Web service operation that returns all sorting tables from DB.
     *
     * @return list of all sorting tables in DB
     */
    @WebMethod(operationName = "getAllSortingTables")
    public List<SortingTables> getAllSortingTables() {
        return em.createNamedQuery("SortingTables.findAll").getResultList();
    }

    /**
     * Web service operation that sorts the table.
     *
     * @param tableID tables's ID to sort
     * @return returns true if everything went correctly (debugging purpose)
     */
    @WebMethod(operationName = "sort")
    public Boolean sort(@WebParam(name = "tableID") int tableID) {
        //getting sorting table
        try {
            SortingTables table = getSortingTable(tableID);
            if (table != null) {
                //getting current index
                List<Numbers> numbers = getSortingTableContent(tableID);

                int index = 0;

                for (int i = 0; i < numbers.size(); i++) {
                    if (numbers.get(i).getIsPointedAt()) {
                        index = numbers.get(i).getIndex();
                    }
                }
                //getting algorithm state
                List<Algorithms> algorithmList = em.createNamedQuery("Algorithms.findByName").setParameter("name", table.getAlgorithm()).getResultList();

                Algorithms algorithm = new Algorithms();

                for (int i = 0; i < algorithmList.size(); i++) {
                    if (algorithmList.get(i).getTableId().getId() == tableID) {
                        algorithm = algorithmList.get(i);
                    }
                }
                //getting command
                Commands command = Commands.COMMAND_START_BUBBLE;

                switch (table.getAlgorithm().toUpperCase()) {
                    case "BUBBLE":
                        command = Commands.COMMAND_START_BUBBLE;
                        break;
                    case "BOGO":
                        command = Commands.COMMAND_START_BOGO;
                        break;
                    case "INSERTION":
                        command = Commands.COMMAND_START_INSERTION;
                        break;
                }

                //creating model to sort the table
                SortModel model = new SortModel(command, numbers, algorithm.getState(), index);

                //sorting
                try {
                    model.receiveCommand(Commands.COMMAND_CONTINUE);
                } catch (OutOfSupposedRangeException exception) {
                    System.err.println(exception.getMessage());
                }

                algorithm.setState(model.getSorterState());
                if (model.getSorterState() == 0) {
                    table.setIsSorted(Boolean.TRUE);
                }
                numbers.forEach((n) -> {
                    if (n.getIndex() == model.getIndex()) {
                        n.setIsPointedAt(true);
                    } else {
                        n.setIsPointedAt(false);
                    }
                });

                //updating DB
                try {
                    merge(table, algorithm, numbers);
                } catch (Exception exception) {
                    System.err.println(exception.getMessage());
                }
            } else {
                return Boolean.FALSE;
            }
        } catch (NoResultException exception) {
            System.err.println(exception.getMessage());
            return Boolean.FALSE;
        }
        return Boolean.TRUE;
    }

    /**
     * Web service operation that returns a sorting table of ID = tableID.
     *
     * @param tableID tables's ID to be found
     * @return found SortingTable or null if there is no sorting table with such
     * ID
     */
    @WebMethod(operationName = "getSortingTable")
    public SortingTables getSortingTable(@WebParam(name = "tableID") final int tableID) {
        SortingTables table;
        try {
            table = (SortingTables) em.createNamedQuery("SortingTables.findById").setParameter("id", tableID).getSingleResult();
        } catch (NoResultException exception) {
            return null;
        }
        return table;
    }

    /**
     * Web service operation that return list of all algorithms that are 
     * currently in DB.
     *
     * @return list of all algorithms in DB
     */
    @WebMethod(operationName = "getAllAlgorithms")
    public List<Algorithms> getAllAlgorithms() {
        return em.createNamedQuery("Algorithms.findAll").getResultList();
    }

    /**
     * Web service operation that return list of all numbers that are currently 
     * in DB.
     *
     * @return list of all numbers in DB
     */
    @WebMethod(operationName = "getAllNumbers")
    public List<Numbers> getAllNumbers() {
        //TODO write your implementation code here:
        return em.createNamedQuery("Numbers.findAll").getResultList();
    }

    /**
     * Method used for adding new entities to DB.
     * @param table A sorting table to be added
     * @param algorithm An algorithm to be added
     * @param numbers A number to be added
     * @throws Exception - thrown by 'persist'
     */
    public void persist(SortingTables table, Algorithms algorithm, List<Numbers> numbers) throws Exception {
        utx.begin();
        em.persist(table);
        em.persist(algorithm);
        for (int i = 0; i < numbers.size(); i++) {
            em.persist(numbers.get(i));
        }
        utx.commit();
    }

    /**
     * Method used for updating entities in DB.
     * @param table A sorting table to be updated
     * @param algorithm An algorithm to be updated
     * @param numbers A number to be updated
     * @throws Exception - thrown by 'merge'
     */
    public void merge(SortingTables table, Algorithms algorithm, List<Numbers> numbers) throws Exception {
        utx.begin();
        em.merge(table);
        em.merge(algorithm);
        for (int i = 0; i < numbers.size(); i++) {
            em.merge(numbers.get(i));
        }
        utx.commit();
    }

    /**
     * Web service operation that return content of a sorting table of 
     * ID = tableID.
     *
     * @param tableID Sorting table's ID.
     * @return List of Nubmers that are located in a table of ID = tableID.
     */
    @WebMethod(operationName = "getSortingTableContent")
    public List<Numbers> getSortingTableContent(@WebParam(name = "tableID") final int tableID) {
        List<Numbers> allNumbers = em.createNamedQuery("Numbers.findAll").getResultList();
        List<Numbers> returnedNumbers = new ArrayList<>();

        for (int i = 0; i < allNumbers.size(); i++) {
            if (allNumbers.get(i).getTableId().getId() == tableID) {
                returnedNumbers.add(allNumbers.get(i));
            }
        }

        return returnedNumbers;
    }

    /**
     * Web service operation that return an algorithm that sorts the table of
     * ID = tableID
     *
     * @param tableID Sorting table's ID.
     * @return Algorithm that sorts the table of ID = tableID
     */
    @WebMethod(operationName = "getAlgorithm")
    public Algorithms getAlgorithm(@WebParam(name = "tableID") final int tableID) {
        List<Algorithms> algorithmList = getAllAlgorithms();
        for (int i = 0; i < algorithmList.size(); i++) {
            if (algorithmList.get(i).getTableId().getId() == tableID) {
                return algorithmList.get(i);
            }
        }
        return null;
    }
}
