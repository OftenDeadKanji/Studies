package ProjektyGminne.Encje;

import ProjektyGminne.Encje.Głosy;
import ProjektyGminne.Encje.Operacje;
import ProjektyGminne.Encje.Wyniki;
import ProjektyGminne.Encje.Załączniki;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2020-02-09T19:55:38")
@StaticMetamodel(Projekty.class)
public class Projekty_ { 

    public static volatile SingularAttribute<Projekty, Boolean> czyZakończony;
    public static volatile SingularAttribute<Projekty, String> czasTrwania;
    public static volatile SingularAttribute<Projekty, String> dataGłosowania;
    public static volatile SingularAttribute<Projekty, String> dzielnica;
    public static volatile SingularAttribute<Projekty, Boolean> czyWprowadzony;
    public static volatile SingularAttribute<Projekty, String> nazwa;
    public static volatile SingularAttribute<Projekty, Integer> koszt;
    public static volatile ListAttribute<Projekty, Załączniki> załącznikiList;
    public static volatile SingularAttribute<Projekty, Long> idP;
    public static volatile ListAttribute<Projekty, Wyniki> wynikiList;
    public static volatile ListAttribute<Projekty, Głosy> głosyList;
    public static volatile ListAttribute<Projekty, Operacje> operacjeList;
    public static volatile SingularAttribute<Projekty, String> opis;

}