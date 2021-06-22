package ProjektyGminneAdmin.Entities;

import ProjektyGminneAdmin.Entities.Mieszkańcy;
import ProjektyGminneAdmin.Entities.Projekty;
import java.util.Date;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2020-02-09T19:55:47")
@StaticMetamodel(Głosy.class)
public class Głosy_ { 

    public static volatile SingularAttribute<Głosy, Mieszkańcy> idM;
    public static volatile SingularAttribute<Głosy, Date> data;
    public static volatile SingularAttribute<Głosy, Projekty> idP;
    public static volatile SingularAttribute<Głosy, Long> idG;

}