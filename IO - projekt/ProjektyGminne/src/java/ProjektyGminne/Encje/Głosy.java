/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Encje;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlRootElement;

/**
 * Klasa reprezentująca tabelę Głosy.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */
@Cacheable(false)
@Entity
@Table(name = "G\u0141OSY", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "G\u0142osy.findAll", query = "SELECT g FROM G\u0142osy g")
    , @NamedQuery(name = "G\u0142osy.findByIdG", query = "SELECT g FROM G\u0142osy g WHERE g.idG = :idG")
    , @NamedQuery(name = "G\u0142osy.findByData", query = "SELECT g FROM G\u0142osy g WHERE g.data = :data")})
public class Głosy implements Serializable {

    private static final long serialVersionUID = 1L;
    
    /**
     * ID głosu - nadawane automatycznie przy wstawianiu do BD.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_G")
    private Long idG;
    
    /**
     * Data oddania głosu.
     */
    @Column(name = "DATA")
    @Temporal(TemporalType.DATE)
    private Date data;
    
    /**
     * Mieszkaniec oddający głos.
     */
    @JoinColumn(name = "ID_M", referencedColumnName = "ID_M")
    @ManyToOne
    private Mieszkańcy idM;
    /**
     * Projekt, na który został oddany głos.
     */
    @JoinColumn(name = "ID_P", referencedColumnName = "ID_P")
    @ManyToOne
    private Projekty idP;

    public Głosy() {
    }

    public Głosy(Long idG) {
        this.idG = idG;
    }

    /**
     * Metoda umożliwiająca ustawienie wszystkich potrzebnych pól obiektu.
     * @param data - data oddania głosu.
     * @param idM - mieszkaniec, który oddał głos
     * @param idP - projekt, na który został oddany głos
     */
    public void setGłos(Date data, Mieszkańcy idM, Projekty idP){
        this.data = data;
        this.idM = idM;
        this.idP = idP;
    }
    
    public Long getIdG() {
        return idG;
    }

    public void setIdG(Long idG) {
        this.idG = idG;
    }

    public Date getData() {
        return data;
    }

    public void setData(Date data) {
        this.data = data;
    }

    public Mieszkańcy getIdM() {
        return idM;
    }

    public void setIdM(Mieszkańcy idM) {
        this.idM = idM;
    }

    public Projekty getIdP() {
        return idP;
    }

    public void setIdP(Projekty idP) {
        this.idP = idP;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idG != null ? idG.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Głosy)) {
            return false;
        }
        Głosy other = (Głosy) object;
        if ((this.idG == null && other.idG != null) || (this.idG != null && !this.idG.equals(other.idG))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminne.Encje.G\u0142osy[ idG=" + idG + " ]";
    }
    
}
