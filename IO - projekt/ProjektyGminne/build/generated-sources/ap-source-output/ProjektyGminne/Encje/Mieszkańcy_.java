package ProjektyGminne.Encje;

import ProjektyGminne.Encje.Głosy;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2020-02-09T19:55:38")
@StaticMetamodel(Mieszkańcy.class)
public class Mieszkańcy_ { 

    public static volatile SingularAttribute<Mieszkańcy, String> hasło;
    public static volatile SingularAttribute<Mieszkańcy, Long> idM;
    public static volatile SingularAttribute<Mieszkańcy, String> adresEmail;
    public static volatile ListAttribute<Mieszkańcy, Głosy> głosyList;
    public static volatile SingularAttribute<Mieszkańcy, String> login;
    public static volatile SingularAttribute<Mieszkańcy, Boolean> czyZagłosował;

}