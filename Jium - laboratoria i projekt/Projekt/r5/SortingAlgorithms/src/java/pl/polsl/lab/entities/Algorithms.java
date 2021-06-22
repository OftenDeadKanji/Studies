/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Table;

/**
 * An DB' entity that represents an algorithm which sorts specific array.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
@Entity
@Table(name = "ALGORITHMS")
public class Algorithms {

    /**
     * ID - Primary key.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ID")
    private int id;

    /**
     * Name of the algorithm.
     */
    @Column(name = "NAME")
    private String name;

    /**
     * An id of a table that it references to.
     */
    @Column(name = "ID_TABLE", updatable = false, insertable = false)
    private int idTable;

    /**
     * A SortingTables object - algorithm sorts this array. OneToOne annotation
     * - one alorithm references to only one sorting table.
     */
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "ID_TABLE", referencedColumnName = "ID")
    private SortingTables table;

    /**
     * A current state of an algorithm. 0 - has already sorted Other - during
     * sorting
     */
    @Column(name = "STATE")
    private Integer currentState;

    /**
     * Parameterless class constructor. It doesn't set any fields.
     */
    public Algorithms() {
    }

    /**
     * A main class constructor. It sets all required fields.
     *
     * @param name - name of the algorithm (bubble, bogo etc).
     * @param table - a table that the algorithm references to.
     */
    public Algorithms(String name, SortingTables table) {
        this.name = name;
        this.table = table;
        this.idTable = table.getId();
        this.currentState = 1;
    }

    /**
     * A getter for an ID.
     *
     * @return Algorithm's ID
     */
    public int getId() {
        return this.id;
    }

    /**
     * A getter for a name
     *
     * @return Algorithm's name
     */
    public String getName() {
        return this.name;
    }

    /**
     * A getter for a table's ID
     *
     * @return A table's ID that algorithm references to.
     */
    public int getIdTable() {
        return this.idTable;
    }

    /**
     * A getter for a current state.
     *
     * @return Algorithm's current state.
     */
    public Integer getCurrentState() {
        return this.currentState;
    }

    /**
     * A getter for a sorting table.
     *
     * @return A table that algorithms references to.
     */
    public SortingTables getTable() {
        return table;
    }

    /**
     * A setter for an ID.
     *
     * @param id algorithm's ID.
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * A setter for a name.
     *
     * @param name Algorithm's name.
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * A setter fot a table's ID.
     *
     * @param idTable A table's ID that the algorithm references to.
     */
    public void setIdTable(int idTable) {
        this.idTable = idTable;
    }

    /**
     * A setter for a sorting table.
     *
     * @param table A tablethat the algorithm references to.
     */
    public void setTable(SortingTables table) {
        this.table = table;
    }

    /**
     * A setter for a current state.
     *
     * @param currentState Algorithm's current state.
     */
    public void setCurrentState(Integer currentState) {
        this.currentState = currentState;
    }
}
