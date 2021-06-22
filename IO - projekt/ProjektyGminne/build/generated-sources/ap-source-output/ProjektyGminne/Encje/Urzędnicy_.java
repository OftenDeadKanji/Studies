package ProjektyGminne.Encje;

import ProjektyGminne.Encje.Operacje;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2020-02-09T19:55:38")
@StaticMetamodel(Urzędnicy.class)
public class Urzędnicy_ { 

    public static volatile SingularAttribute<Urzędnicy, String> hasło;
    public static volatile SingularAttribute<Urzędnicy, String> imię;
    public static volatile SingularAttribute<Urzędnicy, String> nazwisko;
    public static volatile SingularAttribute<Urzędnicy, Long> idU;
    public static volatile SingularAttribute<Urzędnicy, Integer> idPracownika;
    public static volatile ListAttribute<Urzędnicy, Operacje> operacjeList;

}