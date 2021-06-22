/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminneAdmin.Entities;

import java.io.Serializable;
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
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Kanjiklub
 */
@Cacheable(false)
@Entity
@Table(name = "WYNIKI", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Wyniki.findAll", query = "SELECT w FROM Wyniki w")
    , @NamedQuery(name = "Wyniki.findByIdW", query = "SELECT w FROM Wyniki w WHERE w.idW = :idW")
    , @NamedQuery(name = "Wyniki.findBySuma", query = "SELECT w FROM Wyniki w WHERE w.suma = :suma")})
public class Wyniki implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_W")
    private Long idW;
    @Column(name = "SUMA")
    private Integer suma;
    @JoinColumn(name = "ID_P", referencedColumnName = "ID_P")
    @ManyToOne
    private Projekty idP;

    public Wyniki() {
    }

    public Wyniki(Long idW) {
        this.idW = idW;
    }

    public void setWynik(Integer suma, Projekty projekt){
        this.suma = suma;
        this.idP = projekt;
    }
    
    public Long getIdW() {
        return idW;
    }

    public void setIdW(Long idW) {
        this.idW = idW;
    }

    public Integer getSuma() {
        return suma;
    }

    public void setSuma(Integer suma) {
        this.suma = suma;
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
        hash += (idW != null ? idW.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Wyniki)) {
            return false;
        }
        Wyniki other = (Wyniki) object;
        if ((this.idW == null && other.idW != null) || (this.idW != null && !this.idW.equals(other.idW))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminneAdmin.Entities.Wyniki[ idW=" + idW + " ]";
    }
    
}
