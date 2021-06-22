/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminneAdmin.ZarzadzanieTabelami;

import ProjektyGminneAdmin.Entities.*;
import java.util.Date;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 * Klasa dodaje testową, ustaloną zawartość do BD.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class DodajTestowaZawartosc {
    
    public void dodajZawartosc(){
        
        //Urzędnicy
        Urzędnicy firstOfficial = new Urzędnicy();
        firstOfficial.setUrzędnik("General", "Grevious", 9762345, "CIS");
        
        Urzędnicy secondOfficial = new Urzędnicy();
        secondOfficial.setUrzędnik("Commander", "Cody", 3415698, "Republic?");
        
        persist(firstOfficial);
        persist(secondOfficial);
        System.out.println("Two Officials added");
        
        
        //Mieszkańcy
        Mieszkańcy firstResident = new Mieszkańcy();
        firstResident.setMieszkaniec("Kenobi", "Satine", "Kenobi@JediMaster.rp", Boolean.FALSE);
        
        Mieszkańcy secondResident = new Mieszkańcy();
        secondResident.setMieszkaniec("Anakin", "Padme", "Anakin@NotJediMaster.rp", Boolean.FALSE);
        
        Mieszkańcy thirdResident = new Mieszkańcy();
        thirdResident.setMieszkaniec("Ahsoka", "?", "Ahsoka@NotJedi.g", Boolean.FALSE);
        
        persist(firstResident);
        persist(secondResident);
        persist(thirdResident);
        System.out.println("Dodano trzech mieszkańców.");
        
        //Projekty
        Projekty firstProject = new Projekty();
        firstProject.setProjekt("Odbudowa świątynia Jedi", "No sporo się będzie działo", "Świątynia Jedi", 5000000, "ok. 4 lata", "30/31 ABY", Boolean.FALSE, Boolean.FALSE);
        
        Projekty secondProject = new Projekty();
        secondProject.setProjekt("Zniszczenie świątyni Jedi", "No sporo się będzie działo", "Świątynia Jedi", 1000000, "ok. 1 miesiąca", "30/31 ABY", Boolean.FALSE, Boolean.FALSE);
        
        persist(firstProject);
        persist(secondProject);
        System.out.println("Dodano dwa projekty.");
        
        //Operacje na projektach
        Operacje firstOperation = new Operacje();
        firstOperation.setOperacja(1, firstProject, secondOfficial); //1 - dodanie projektu, 2 - edycja projektu
        
        Operacje secondOperation = new Operacje();
        secondOperation.setOperacja(1, secondProject, firstOfficial);
        
        persist(firstOperation);
        persist(secondOperation);
        System.out.println("Dodano dwie operacje.");
        
        Załączniki appendix = new Załączniki();
        appendix.setZałącznik("Odbudowa.pdf", "Rok 30_31 ABY/zasoby/załączniki/", firstProject);
        
        persist(appendix);
        System.out.println("Dodane jeden załącznik.");
        
        //Dodatkowa operacja
        Operacje thirdOperation = new Operacje();
        thirdOperation.setOperacja(2, firstProject, firstOfficial); //2 - aktualizacja
        
        persist(thirdOperation);
        System.out.println("Dodano jedną (lub więcej) operacji.");
        
        //Głosy na projekty
        Głosy glos1 = new Głosy();
        glos1.setGłos(new Date(), firstResident, firstProject);
        
        Głosy glos2 = new Głosy();
        glos2.setGłos(new Date(), secondResident, firstProject);
        
        Głosy glos3 = new Głosy();
        glos3.setGłos(new Date(), thirdResident, secondProject);
        
        
        persist(glos1);
        persist(glos3);
        persist(glos2);
        System.out.println("Trzy głosy dodany");      
    }

    public void persist(Object object) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminneAdminPU");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        try {
            em.persist(object);
            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            em.getTransaction().rollback();
        } finally {
            em.close();
        }
    }
}
