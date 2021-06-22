/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.polsl.lab.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * A tables in DB that consists of sorting tables.
 * 
 * @author Mateusz Chłopek
 * @version 1.0
 */

@Entity
@Table(name="SORTING_TABLES")
public class SortingTables {
    
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "ID")
    private Integer id;
    
    @Column(name = "SIZE")
    private Integer size;
    
    @Column(name = "ALGORITHM")
    private String algorithm;
    
    @Column(name = "IS_SORTED")
    private Boolean isSorted;
    
    public SortingTables(){
        this.size = 20;
        this.algorithm = "bubble";
    }
    
    public SortingTables(Integer size, String algorithm){
        this.size = size;
        if(algorithm.toUpperCase().equals("BUBBLE"))
            this.algorithm = "bubble";
        else if (algorithm.toUpperCase().equals("bogo"))
            this.algorithm = "bogo";
        else
            this.algorithm = "insertion";
    }
    
    public Integer getId(){
        return this.id;
    }
    
    public Integer getSize(){
        return this.size;
    }
    
    public String getAlgorithm(){
        return this.algorithm;
    }
    
    public Boolean getIsSorted() {
        return this.isSorted;
    }
    
}
