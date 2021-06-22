/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminneAdmin;

import ProjektyGminneAdmin.ZarzadzanieTabelami.DodajTestowaZawartosc;
import ProjektyGminneAdmin.ZarzadzanieTabelami.Zarzadzanie;
import ProjektyGminneAdmin.ZarzadzanieTabelami.DodanieTabel;
import ProjektyGminneAdmin.ZarzadzanieTabelami.UsuniecieTabel;
import java.util.InputMismatchException;
import java.util.Locale;
import java.util.Scanner;

/**
 * Główna klasa obsługująca polecenia ze strony admina.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
public class ProjektyGminneAdmin {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println("Projekty gminne - admin.");
        Scanner scanner = new Scanner(System.in);
        Boolean warunekPetli = true;
        int wybor;
        while (warunekPetli) {

            System.out.println("\n1. Dodanie wszystkich tabel."
                    + "\n2. Usunięcie wszystkich tabel."
                    + "\n3. Dodanie zawartości testowej."
                    + "\n4. Dalsze zarządzanie."
                    + "\n0. Wyjście.");
            try {
                wybor = scanner.nextInt();
            } catch (InputMismatchException wyjatek) {
                wybor = -1;
                scanner = new Scanner(System.in);
            }
            switch (wybor) {
                case 1:
                    DodanieTabel dod = new DodanieTabel();
                    dod.dodajTabele();
                    break;
                case 2:
                    UsuniecieTabel usu = new UsuniecieTabel();
                    usu.usunTabele();
                    break;
                case 3:
                    DodajTestowaZawartosc test = new DodajTestowaZawartosc();
                    test.dodajZawartosc();
                    break;
                case 4:
                    Zarzadzanie nowa = new Zarzadzanie();
                    nowa.uruchom();
                    break;
                case 0:
                    warunekPetli = false;
                    break;
                default:
                    System.out.println("Brak takiej opcji");
                    break;
            }

        }

    }

}
