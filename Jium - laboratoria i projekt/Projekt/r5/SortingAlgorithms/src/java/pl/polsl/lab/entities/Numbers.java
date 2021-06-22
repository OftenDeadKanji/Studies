/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

/**
 * A DB entity that represents a number in a sorting array.
 *
 * @author Mateusz Chłopek
 * @version 1.0
 */
@Entity
@Table(name = "NUMBERS")
public class Numbers {

    /**
     * Primary key.
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ID")
    private int id;

    /**
     * Value of the number.
     */
    @Column(name = "VALUE")
    private Integer value;

    /**
     * A table's ID where this number is located.
     */
    @Column(name = "TABLE_ID", updatable = false, insertable = false)
    private int tableId;

    /**
     * A table where this number is located.
     */
    @ManyToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "TABLE_ID", referencedColumnName = "ID")
    private SortingTables table;

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
     * A parameterless constructor. It sets a default values of private fields.
     */
    public Numbers() {
        this.value = 0;
        this.index = 0;
        this.isPointedAt = false;
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
        this.table = table;
        this.tableId = table.getId();
        this.index = index;
        this.isPointedAt = false;
    }

    /**
     * A getter for an ID.
     *
     * @return Number's ID.
     */
    public int getId() {
        return id;
    }

    /**
     * A setter for an ID.
     *
     * @param id Number's ID.
     */
    public void setId(int id) {
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
     * A getter for a table's ID.
     *
     * @return Table's ID.
     */
    public int getTableId() {
        return tableId;
    }

    /**
     * A setter for a table's ID.
     *
     * @param tableId Table's ID.
     */
    public void setTableId(int tableId) {
        this.tableId = tableId;
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
     * @return Sorting table where ther nubmer is located.
     */
    public SortingTables getTable() {
        return this.table;
    }

}
