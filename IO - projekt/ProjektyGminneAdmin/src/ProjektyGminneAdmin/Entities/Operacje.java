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
@Table(name = "OPERACJE", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Operacje.findAll", query = "SELECT o FROM Operacje o")
    , @NamedQuery(name = "Operacje.findByIdO", query = "SELECT o FROM Operacje o WHERE o.idO = :idO")
    , @NamedQuery(name = "Operacje.findByRodzaj", query = "SELECT o FROM Operacje o WHERE o.rodzaj = :rodzaj")})
public class Operacje implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_O")
    private Long idO;
    @Column(name = "RODZAJ")
    private Integer rodzaj;
    @JoinColumn(name = "ID_P", referencedColumnName = "ID_P")
    @ManyToOne
    private Projekty idP;
    @JoinColumn(name = "ID_U", referencedColumnName = "ID_U")
    @ManyToOne
    private Urzędnicy idU;

    public Operacje() {
    }

    public Operacje(Long idO) {
        this.idO = idO;
    }

    public void setOperacja(Integer rodzaj, Projekty idP, Urzędnicy idU){
        this.rodzaj = rodzaj;
        this.idP = idP;
        this.idU = idU;
    }
    
    public Long getIdO() {
        return idO;
    }

    public void setIdO(Long idO) {
        this.idO = idO;
    }

    public Integer getRodzaj() {
        return rodzaj;
    }

    public void setRodzaj(Integer rodzaj) {
        this.rodzaj = rodzaj;
    }

    public Projekty getIdP() {
        return idP;
    }

    public void setIdP(Projekty idP) {
        this.idP = idP;
    }

    public Urzędnicy getIdU() {
        return idU;
    }

    public void setIdU(Urzędnicy idU) {
        this.idU = idU;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idO != null ? idO.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Operacje)) {
            return false;
        }
        Operacje other = (Operacje) object;
        if ((this.idO == null && other.idO != null) || (this.idO != null && !this.idO.equals(other.idO))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminneAdmin.Entities.Operacje[ idO=" + idO + " ]";
    }
    
}
