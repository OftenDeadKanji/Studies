/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import java.io.Serializable;
import javax.persistence.Basic;
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
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 * An DB' entity that represents an algorithm which sorts specific array.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
@Entity
@Table(name = "ALGORITHMS", catalog = "", schema = "KENOBI")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Algorithms.findAll", query = "SELECT a FROM Algorithms a")
    , @NamedQuery(name = "Algorithms.findById", query = "SELECT a FROM Algorithms a WHERE a.id = :id")
    , @NamedQuery(name = "Algorithms.findByName", query = "SELECT a FROM Algorithms a WHERE a.name = :name")
    , @NamedQuery(name = "Algorithms.findByState", query = "SELECT a FROM Algorithms a WHERE a.state = :state")})
public class Algorithms implements Serializable {

    private static final long serialVersionUID = 1L;
    /**
     * ID - Primary key.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID")
    private Integer id;
    /**
     * Name of the algorithm.
     */
    @Size(max = 20)
    @Column(name = "NAME")
    private String name;
    /**
     * A current state of an algorithm. 0 - has already sorted Other - during
     * sorting
     */
    @Column(name = "STATE")
    private Integer state;

    /**
     * A SortingTables object - algorithm sorts this array.
     */
    @JoinColumn(name = "TABLE_ID", referencedColumnName = "ID")
    @ManyToOne
    private SortingTables tableId;

    /**
     * Parameterless class constructor.
     */
    public Algorithms() {
    }

    /**
     * A class constructor that set the ID field.
     *
     * @param id ID to be set.
     */
    public Algorithms(Integer id) {
        this.id = id;
    }

    /**
     * A getter for an ID.
     *
     * @return Algorithm's ID
     */
    public Integer getId() {
        return id;
    }

    /**
     * A setter for an ID.
     *
     * @param id algorithm's ID.
     */
    public void setId(Integer id) {
        this.id = id;
    }

    /**
     * A getter for a name
     *
     * @return Algorithm's name
     */
    public String getName() {
        return name;
    }

    /**
     * A setter for a name.
     *
     * @param name Algorithm's name.
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * A getter for a current state.
     *
     * @return Algorithm's current state.
     */
    public Integer getState() {
        return state;
    }

    /**
     * A setter for a current state.
     *
     * @param state Algorithm's current state.
     */
    public void setState(Integer state) {
        this.state = state;
    }

    /**
     * A getter for a sorting table.
     *
     * @return A table that algorithms references to.
     */
    public SortingTables getTableId() {
        return tableId;
    }

    /**
     * A setter for a sorting table.
     *
     * @param tableId A tablethat the algorithm references to.
     */
    public void setTableId(SortingTables tableId) {
        this.tableId = tableId;
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
        if (!(object instanceof Algorithms)) {
            return false;
        }
        Algorithms other = (Algorithms) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "pl.polsl.lab.Entities.Algorithms[ id=" + id + " ]";
    }

}
