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
@Table(name = "ZA\u0141\u0104CZNIKI", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Za\u0142\u0105czniki.findAll", query = "SELECT z FROM Za\u0142\u0105czniki z")
    , @NamedQuery(name = "Za\u0142\u0105czniki.findByIdZ", query = "SELECT z FROM Za\u0142\u0105czniki z WHERE z.idZ = :idZ")
    , @NamedQuery(name = "Za\u0142\u0105czniki.findByNazwa", query = "SELECT z FROM Za\u0142\u0105czniki z WHERE z.nazwa = :nazwa")
    , @NamedQuery(name = "Za\u0142\u0105czniki.findBy\u015acie\u017ckaZasobu", query = "SELECT z FROM Za\u0142\u0105czniki z WHERE z.\u015bcie\u017ckaZasobu = :\u015bcie\u017ckaZasobu")})
public class Załączniki implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_Z")
    private Long idZ;
    @Column(name = "\u015aCIE\u017bKA_ZASOBU")
    private String ścieżkaZasobu;
    @Column(name = "NAZWA")
    private String nazwa;
    @JoinColumn(name = "ID_P", referencedColumnName = "ID_P")
    @ManyToOne
    private Projekty idP;

    public Załączniki() {
    }

    public Załączniki(Long idZ) {
        this.idZ = idZ;
    }

    public void setZałącznik(String nazwa, String ścieżka, Projekty projekt) {
        this.nazwa = nazwa;
        this.ścieżkaZasobu = ścieżka;
        this.idP = projekt;
    }

    public Long getIdZ() {
        return idZ;
    }

    public void setIdZ(Long idZ) {
        this.idZ = idZ;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    public String getŚcieżkaZasobu() {
        return ścieżkaZasobu;
    }

    public void setŚcieżkaZasobu(String ścieżkaZasobu) {
        this.ścieżkaZasobu = ścieżkaZasobu;
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
        hash += (idZ != null ? idZ.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Załączniki)) {
            return false;
        }
        Załączniki other = (Załączniki) object;
        if ((this.idZ == null && other.idZ != null) || (this.idZ != null && !this.idZ.equals(other.idZ))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminne.Encje.Za\u0142\u0105czniki[ idZ=" + idZ + " ]";
    }

}
