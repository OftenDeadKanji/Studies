/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Encje;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Kanjiklub
 */
@Cacheable(false)
@Entity
@Table(name = "URZ\u0118DNICY", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Urz\u0119dnicy.findAll", query = "SELECT u FROM Urz\u0119dnicy u")
    , @NamedQuery(name = "Urz\u0119dnicy.findByIdU", query = "SELECT u FROM Urz\u0119dnicy u WHERE u.idU = :idU")
    , @NamedQuery(name = "Urz\u0119dnicy.findByImi\u0119", query = "SELECT u FROM Urz\u0119dnicy u WHERE u.imi\u0119 = :imi\u0119")
    , @NamedQuery(name = "Urz\u0119dnicy.findByNazwisko", query = "SELECT u FROM Urz\u0119dnicy u WHERE u.nazwisko = :nazwisko")
    , @NamedQuery(name = "Urz\u0119dnicy.findByIdPracownika", query = "SELECT u FROM Urz\u0119dnicy u WHERE u.idPracownika = :idPracownika")
    , @NamedQuery(name = "Urz\u0119dnicy.findByHas\u0142o", query = "SELECT u FROM Urz\u0119dnicy u WHERE u.has\u0142o = :has\u0142o")})
public class Urzędnicy implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_U")
    private Long idU;
    @Size(max = 30)
    @Column(name = "IMI\u0118")
    private String imię;
    @Size(max = 30)
    @Column(name = "NAZWISKO")
    private String nazwisko;
    @Column(name = "ID_PRACOWNIKA")
    private Integer idPracownika;
    @Size(max = 30)
    @Column(name = "HAS\u0141O")
    private String hasło;
    @OneToMany(mappedBy = "idU")
    private List<Operacje> operacjeList;

    public Urzędnicy() {
    }

    public Urzędnicy(Long idU) {
        this.idU = idU;
    }

    public void setUrzędnik(String imię, String nazwisko, Integer idPracownika, String hasło) {
        this.imię = imię;
        this.nazwisko = nazwisko;
        this.idPracownika = idPracownika;
        this.hasło = hasło;
    }
    
    public Long getIdU() {
        return idU;
    }

    public void setIdU(Long idU) {
        this.idU = idU;
    }

    public String getImię() {
        return imię;
    }

    public void setImię(String imię) {
        this.imię = imię;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public Integer getIdPracownika() {
        return idPracownika;
    }

    public void setIdPracownika(Integer idPracownika) {
        this.idPracownika = idPracownika;
    }

    public String getHasło() {
        return hasło;
    }

    public void setHasło(String hasło) {
        this.hasło = hasło;
    }

    @XmlTransient
    public List<Operacje> getOperacjeList() {
        return operacjeList;
    }

    public void setOperacjeList(List<Operacje> operacjeList) {
        this.operacjeList = operacjeList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idU != null ? idU.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Urzędnicy)) {
            return false;
        }
        Urzędnicy other = (Urzędnicy) object;
        if ((this.idU == null && other.idU != null) || (this.idU != null && !this.idU.equals(other.idU))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminne.Encje.Urz\u0119dnicy[ idU=" + idU + " ]";
    }
    
}
