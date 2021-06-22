/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
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
 * A DB entity that represents a number in a sorting array.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
@Entity
@Table(name = "NUMBERS", catalog = "", schema = "KENOBI")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Numbers.findAll", query = "SELECT n FROM Numbers n")
    , @NamedQuery(name = "Numbers.findById", query = "SELECT n FROM Numbers n WHERE n.id = :id")
    , @NamedQuery(name = "Numbers.findByValue", query = "SELECT n FROM Numbers n WHERE n.value = :value")
    , @NamedQuery(name = "Numbers.findByIndex", query = "SELECT n FROM Numbers n WHERE n.index = :index")
    , @NamedQuery(name = "Numbers.findByIsPointedAt", query = "SELECT n FROM Numbers n WHERE n.isPointedAt = :isPointedAt")})
public class Numbers implements Serializable {

    private static final long serialVersionUID = 1L;
    /**
     * Primary key.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID")
    private Integer id;
    /**
     * Value of the number.
     */
    @Column(name = "VALUE")
    private Integer value;
    /**
     * A number's index in an array.
     */
    @Column(name = "INDEX")
    private Integer index;
    /**
     * This indicades if the number is currently pointed at by an algorithm.
     */
    @Column(name = "IS_POINTED_AT")
    private Boolean isPointedAt;
    /**
     * A table where this number is located.
     */
    @JoinColumn(name = "TABLE_ID", referencedColumnName = "ID")
    @ManyToOne(cascade = CascadeType.ALL)
    private SortingTables tableId;

    /**
     * A parameterless constructor.
     */
    public Numbers() {
    }

    /**
     * A class constructor that sets the ID field.
     *
     * @param id ID to be set.
     */
    public Numbers(Integer id) {
        this.id = id;
    }
    
    /**
     * A class constructor that sets the value field.
     * @param value a new number's value.
     * @param index current number's index. 
     */
    public Numbers(int value, int index){
        this.value = value;
        this.index = index;
    }
    
    /**
     * Main class constructor.
     *
     * @param value Value of thr number.
     * @param table Sorting table where the number is located.
     * @param index An index in the sorting table.
     */
    public Numbers(Integer value, SortingTables table, Integer index) {
        this.value = value;
        this.tableId = table;
        this.index = index;
        this.isPointedAt = false;
    }

    /**
     * A getter for an ID.
     *
     * @return Number's ID.
     */
    public Integer getId() {
        return id;
    }

    /**
     * A setter for an ID.
     *
     * @param id Number's ID.
     */
    public void setId(Integer id) {
        this.id = id;
    }

    /**
     * A getter for a value.
     *
     * @return Number's value.
     */
    public Integer getValue() {
        return value;
    }

    /**
     * A setter for a value
     *
     * @param value Number's value.
     */
    public void setValue(Integer value) {
        this.value = value;
    }

    /**
     * A getter for a nubmer's index.
     *
     * @return Nubmer's index.
     */
    public Integer getIndex() {
        return index;
    }

    /**
     * A setter for a number's index.
     *
     * @param index Number's index.
     */
    public void setIndex(Integer index) {
        this.index = index;
    }

    /**
     * A getter for a boolean isPointeedAt.
     *
     * @return Number's variable - isPointedAt.
     */
    public Boolean getIsPointedAt() {
        return isPointedAt;
    }

    /**
     * A setter for a boolean isPointeedAt.
     *
     * @param isPointedAt Number's variable - isPointedAt.
     */
    public void setIsPointedAt(Boolean isPointedAt) {
        this.isPointedAt = isPointedAt;
    }

    /**
     * A getter for a sorting table.
     *
     * @return Sorting table where the number is located.
     */
    public SortingTables getTableId() {
        return tableId;
    }

    /**
     * A setter for a sorting table
     *
     * @param tableId Sorting table where the number is located.
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
        if (!(object instanceof Numbers)) {
            return false;
        }
        Numbers other = (Numbers) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "pl.polsl.lab.Entities.Numbers[ id=" + id + " ]";
    }

}
