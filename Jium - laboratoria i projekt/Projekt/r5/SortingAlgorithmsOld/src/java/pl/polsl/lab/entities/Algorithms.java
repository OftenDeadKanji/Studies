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
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Table;

/**
 *
 * @author Kanjiklub
 */

@Entity
@Table(name="ALGORITHMS")
public class Algorithms {
    
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "ID")
    private Integer id;
    
    @Column(name = "NAME")
    private String name;
    
    @Column(name = "ID_TABLE", updatable = false, insertable = false)
    private Integer idTable;
    
    @OneToOne
    @JoinColumn(name = "ID_TABLE")
    private SortingTables table;
    
    @Column(name = "STATE")
    private Integer currentState;
    
    public Algorithms(){
        
    }
    
    public Algorithms(String name, SortingTables table){
        this.name = name;
        this.table = table;
        this.currentState = 0;
    }
    
    public Integer getId(){
        return this.id;
    }
    
    public String getName(){
        return this.name;
    }
    
    public Integer getIdTable(){
        return this.idTable;
    }
    
    public Integer getCurrentState(){
        return this.currentState;
    }
}
