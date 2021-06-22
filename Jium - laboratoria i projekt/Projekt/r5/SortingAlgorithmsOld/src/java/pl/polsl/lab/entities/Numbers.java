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
import javax.persistence.ManyToOne;
import javax.persistence.Table;

/**
 *
 * @author Kanjiklub
 */

@Entity
@Table(name="NUMBERS")
public class Numbers {
    
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "ID")
    private Integer id;
    
    //@ManyToOne
    //@JoinColumn(name = "ID_TABLE")
    //private Integer idTable;
    
    @Column(name = "VALUE")
    private Integer value;
    
    @Column(name = "INDEX")
    private Integer index;
    
    @Column(name = "IS_POINTED_AT")
    private Boolean isPointedAt;
    
    public Numbers(){
        
    }
    
    public Numbers(Integer index){
        this.index = index;
    }
    
    public Integer getId(){
        return this.id;
    }
    
    //public Integer getIdTable(){
    //    return this.idTable;
    //}
    
    public Integer getValue(){
        return this.value;
    }
    
    public Integer getIndex(){
        return this.index;
    }
    
    public Boolean getIsPointedAt(){
        return this.isPointedAt;
    }
}
