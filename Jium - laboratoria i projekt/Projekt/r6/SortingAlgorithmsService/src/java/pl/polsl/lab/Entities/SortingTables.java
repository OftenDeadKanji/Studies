/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
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
 * A table in DB that represents a sorting table.
 *
 * @author Mateusz Chłopek
 * @version 1.1
 */
@Entity
@Table(name = "SORTING_TABLES", catalog = "", schema = "KENOBI")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "SortingTables.findAll", query = "SELECT s FROM SortingTables s")
    , @NamedQuery(name = "SortingTables.findById", query = "SELECT s FROM SortingTables s WHERE s.id = :id")
    , @NamedQuery(name = "SortingTables.findBySize", query = "SELECT s FROM SortingTables s WHERE s.size = :size")
    , @NamedQuery(name = "SortingTables.findByAlgorithm", query = "SELECT s FROM SortingTables s WHERE s.algorithm = :algorithm")
    , @NamedQuery(name = "SortingTables.findByIsSorted", query = "SELECT s FROM SortingTables s WHERE s.isSorted = :isSorted")})
public class SortingTables implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * Primary key - table's ID.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID")
    private Integer id;
    /**
     * A size of an array.
     */
    @Column(name = "SIZE")
    private Integer size;
    /**
     * An algorithm's name that sorts the table.
     */
    @Size(max = 20)
    @Column(name = "ALGORITHM")
    private String algorithm;
    /**
     * This field indicates if table has been already sorted.
     */
    @Column(name = "IS_SORTED")
    private Boolean isSorted;
    
    /**
     * An algorithm that sorts the table.
     */
    @OneToMany(mappedBy = "tableId", cascade = CascadeType.PERSIST)
    private List<Numbers> numbersList;
    
    /**
     * A list of numbers that are located in this array.
     */
    @OneToMany(mappedBy = "tableId")
    private List<Algorithms> algorithmsList;

    /**
     * A parameterless constructor.
     */
    public SortingTables() {
    }

    /**
     * A class constructor that sets the ID field.
     *
     * @param id
     */
    public SortingTables(Integer id) {
        this.id = id;
    }

    /**
     * A class constructor that sets size and algorithm field.
     *
     * @param size Size of an array.
     * @param algorithm Algorithm's name that sorts the table.
     */
    public SortingTables(Integer size, String algorithm) {
        this.size = size;
        switch (algorithm.toUpperCase()) {
            case "BUBBLE":
                this.algorithm = "bubble";
                break;
            case "BOGO":
                this.algorithm = "bogo";
                break;
            default:
                this.algorithm = "insertion";
                break;
        }
        this.isSorted = false;
    }
    
    /**
     * A getter for an ID.
     *
     * @return Table's ID.
     */
    public Integer getId() {
        return id;
    }

    /**
     * A setter for an ID.
     *
     * @param id Table's ID.
     */
    public void setId(Integer id) {
        this.id = id;
    }

    /**
     * A getter for a table's size.
     *
     * @return Table's size.
     */
    public Integer getSize() {
        return size;
    }

    /**
     * A setter for a array's size.
     *
     * @param size Array's size.
     */
    public void setSize(Integer size) {
        this.size = size;
    }

    /**
     * A getter for a algorithm's name.
     *
     * @return Table's algorithm's name.
     */
    public String getAlgorithm() {
        return algorithm;
    }

    /**
     * A setter for an algorithm's name.
     *
     * @param algorithm Table's algorithm's name.
     */
    public void setAlgorithm(String algorithm) {
        this.algorithm = algorithm;
    }

    /**
     * A getter for a isSorted variable.
     *
     * @return true if table has been already sorted, false otherwise.
     */
    public Boolean getIsSorted() {
        return isSorted;
    }

    /**
     * A setter for a isSorted variable.
     *
     * @param isSorted true if array has been sorted.
     */
    public void setIsSorted(Boolean isSorted) {
        this.isSorted = isSorted;
    }

    /**
     * A getter for a content of an array.
     *
     * @return List of numbers that are array's content.
     */
    @XmlTransient
    public List<Numbers> getNumbersList() {
        return numbersList;
    }

    /**
     * A setter for a table's number list.
     *
     * @param numbersList Content of a table - list of numbers.
     */
    public void setNumbersList(List<Numbers> numbersList) {
        this.numbersList = numbersList;
    }

    /**
     * A getter for algorithm list that sort the table.
     *
     * @return list of algorithms.
     */
    @XmlTransient
    public List<Algorithms> getAlgorithmsList() {
        return algorithmsList;
    }

    /**
     * A setter for algorithm list.
     *
     * @param algorithmsList a list to set as a algorithm list
     */
    public void setAlgorithmsList(List<Algorithms> algorithmsList) {
        this.algorithmsList = algorithmsList;
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
        if (!(object instanceof SortingTables)) {
            return false;
        }
        SortingTables other = (SortingTables) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "pl.polsl.lab.Entities.SortingTables[ id=" + id + " ]";
    }

}
