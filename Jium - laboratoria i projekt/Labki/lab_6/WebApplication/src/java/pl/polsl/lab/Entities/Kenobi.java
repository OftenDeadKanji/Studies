/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.Entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Kanjiklub
 */
@Entity
@Table(name = "KENOBI")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Kenobi.findAll", query = "SELECT k FROM Kenobi k")
    , @NamedQuery(name = "Kenobi.findById", query = "SELECT k FROM Kenobi k WHERE k.id = :id")
    , @NamedQuery(name = "Kenobi.findByRank", query = "SELECT k FROM Kenobi k WHERE k.rank = :rank")})
public class Kenobi implements Serializable {

    private static final long serialVersionUID = 1L;
    @GeneratedValue
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID")
    private Long id;
    @Size(max = 255)
    @Column(name = "RANK")
    private String rank;

    public Kenobi() {
    }

    public Kenobi(Long id) {
        this.id = id;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getRank() {
        return rank;
    }

    public void setRank(String rank) {
        this.rank = rank;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Kenobi)) {
            return false;
        }
        Kenobi other = (Kenobi) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "pl.polsl.lab.Entities.Kenobi[ id=" + id + " ]";
    }
    
}
