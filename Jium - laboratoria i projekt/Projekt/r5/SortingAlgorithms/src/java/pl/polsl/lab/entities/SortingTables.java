/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import java.util.List;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

/**
 * A table in DB that represents a sorting table.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
@Entity
@Table(name = "SORTING_TABLES")
public class SortingTables {

    /**
     * Primary key - table's ID.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ID")
    private int id;

    /**
     * A size of an array.
     */
    @Column(name = "SIZE")
    private Integer size;

    /**
     * An algorithm's name that sorts the table.
     */
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
    @OneToOne(mappedBy = "table")
    private Algorithms algorithmFK;

    /**
     * A list of numbers that are located in this array.
     */
    @OneToMany(mappedBy = "table")
    private List<Numbers> content;

    /**
     * A parameterless constructor.
     */
    public SortingTables() {
        this.size = 20;
        this.algorithm = "bubble";
    }

    /**
     * A main class constructor.
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
    public int getId() {
        return this.id;
    }

    /**
     * A getter for a table's size.
     *
     * @return Table's size.
     */
    public Integer getSize() {
        return this.size;
    }

    /**
     * A getter for a algorithm's name.
     *
     * @return Table's algorithm's name.
     */
    public String getAlgorithm() {
        return this.algorithm;
    }

    /**
     * A getter for a isSorted variable.
     *
     * @return true if table has been already sorted, false otherwise.
     */
    public Boolean getIsSorted() {
        return this.isSorted;
    }

    /**
     * A getter for an algorithm.
     *
     * @return Table's algorithm.
     */
    public Algorithms getAlgorithmFK() {
        return algorithmFK;
    }

    /**
     * A setter for an ID.
     *
     * @param id Table's ID.
     */
    public void setId(int id) {
        this.id = id;
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
     * A setter for an algorithm's name.
     *
     * @param algorithm Table's algorithm's name.
     */
    public void setAlgorithm(String algorithm) {
        this.algorithm = algorithm;
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
     * A setter for an table's algorithm.
     *
     * @param algorithmFK An array's algorithm.
     */
    public void setAlgorithmFK(Algorithms algorithmFK) {
        this.algorithmFK = algorithmFK;
    }

    /**
     * A setter for a table's number list.
     *
     * @param content Content of a table - list of numbers.
     */
    public void setContent(List<Numbers> content) {
        this.content = content;
    }

    /**
     * A getter for a content of an array.
     *
     * @return List of numbers that are array's content.
     */
    public List<Numbers> getContent() {
        return content;
    }

}
