/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminneAdmin.ZarzadzanieTabelami;

import ProjektyGminneAdmin.Entities.Urzędnicy;
import ProjektyGminneAdmin.Entities.Głosy;
import ProjektyGminneAdmin.Entities.Projekty;
import ProjektyGminneAdmin.Entities.Wyniki;
import java.util.List;
import java.util.Objects;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 * Klasa dodaje nową zawartość do BD. Admin sam wybiera co chce dodać i ustawia
 * odpowiednie wartości pól.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class Zarzadzanie {

    public void uruchom() {

        EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminneAdminPU");
        EntityManager em = emf.createEntityManager();

        System.out.println("Zarządzanie bazą danych - Projekty Gminne.");
        try {
            Thread.sleep(500);
        } catch (InterruptedException ex) {
            Logger.getLogger(Zarzadzanie.class.getName()).log(Level.SEVERE, null, ex);
        }

        Scanner input = new Scanner(System.in);

        Boolean warunek = true;
        while (warunek) {
            System.out.println("\n1. Dodać urzędnika."
                    + "\n2. Zliczyć głosy."
                    + "\n0. Powrót.");
            int wybor = input.nextInt();
            switch (wybor) {
                case 1:
                    dodajUrzednika();
                    break;
                case 2:
                    zliczGlosy(em);
                    break;
                case 0:
                    warunek = false;
                    break;
            }
        }
    }

    private void dodajUrzednika() {
        Scanner input;

        input = new Scanner(System.in);
        System.out.print("\nPodaj imię: ");
        String imie = input.nextLine();

        input = new Scanner(System.in);
        System.out.print("Podaj nazwisko: ");
        String nazwisko = input.nextLine();

        input = new Scanner(System.in);
        System.out.print("Podaj id pracownika: ");
        Integer id_p = input.nextInt();

        input = new Scanner(System.in);
        System.out.print("Podaj hasło: ");
        String haslo = input.nextLine();

        Urzędnicy nowy = new Urzędnicy();
        nowy.setUrzędnik(imie, nazwisko, id_p, haslo);
        persist(nowy);
    }

    private void zliczGlosy(EntityManager em) {
        //pobranie wszystkich projektów i głosów
        List<Long> ids = em.createQuery("SELECT p.idP FROM Projekty p GROUP BY p.idP").getResultList();
        List<Głosy> glosy = em.createNamedQuery("Głosy.findAll").getResultList();

        //przejście w pętli po wszystkich id
        for (int i = 0; i < ids.size(); i++) {
            Integer suma = 0;
            for (int j = 0; j < glosy.size(); j++) {
                if (Objects.equals(glosy.get(j).getIdP().getIdP(), ids.get(i))) {
                    suma++;
                }
            }
            //pobranie projektu o danym ID
            Projekty projekt = (Projekty) em.createNamedQuery("Projekty.findByIdP").setParameter("idP", ids.get(i)).getSingleResult();
            projekt.setCzyZakończony(Boolean.TRUE);

            //stworzeniu nowego wyniku
            Wyniki wynik = new Wyniki();
            wynik.setWynik(suma, projekt);

            //dodanie go do BD
            persist(wynik);
            merge(projekt);
        }

        List<Wyniki> wyniki = em.createNamedQuery("Wyniki.findAll").getResultList();
        Projekty projekt = null;
        int max = 0;
        for (Wyniki w : wyniki) {
            if (w.getSuma() > max) {
                max = w.getSuma();
                projekt = w.getIdP();
            }
        }
        if (projekt != null) {
            projekt.setCzyWprowadzony(Boolean.TRUE);
            merge(projekt);
        }

        List<Wyniki> posortowane = em.createQuery("SELECT w FROM Wyniki w ORDER BY w.suma").getResultList();

        for (int i = posortowane.size() - 1; i >= 0; i--) {
            System.out.println(posortowane.get(i).getIdP().getNazwa() + " z liczbą głósów równą " + posortowane.get(i).getSuma());
        }
    }

    private void persist(Object object) {
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

    private void merge(Object object) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("ProjektyGminneAdminPU");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        try {
            em.merge(object);
            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            em.getTransaction().rollback();
        } finally {
            em.close();
        }
    }
}
