/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.Entities;

import java.io.Serializable;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

/**
 *
 * @author Kanjiklub
 */
@Entity
public class Kenobi implements Serializable {

    private String Rank;

    /**
     * Get the value of Rank
     *
     * @return the value of Rank
     */
    public String getRank() {
        return Rank;
    }

    /**
     * Set the value of Rank
     *
     * @param Rank new value of Rank
     */
    public void setRank(String Rank) {
        this.Rank = Rank;
    }

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
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
