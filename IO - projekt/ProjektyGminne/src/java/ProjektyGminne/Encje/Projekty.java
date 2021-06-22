/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProjektyGminne.Encje;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.Cacheable;
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
 *
 * @author Kanjiklub
 */
@Cacheable(false)
@Entity
@Table(name = "PROJEKTY", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Projekty.findAll", query = "SELECT p FROM Projekty p")
    , @NamedQuery(name = "Projekty.findByIdP", query = "SELECT p FROM Projekty p WHERE p.idP = :idP")
    , @NamedQuery(name = "Projekty.findByNazwa", query = "SELECT p FROM Projekty p WHERE p.nazwa = :nazwa")
    , @NamedQuery(name = "Projekty.findByOpis", query = "SELECT p FROM Projekty p WHERE p.opis = :opis")
    , @NamedQuery(name = "Projekty.findByDzielnica", query = "SELECT p FROM Projekty p WHERE p.dzielnica = :dzielnica")
    , @NamedQuery(name = "Projekty.findByKoszt", query = "SELECT p FROM Projekty p WHERE p.koszt = :koszt")
    , @NamedQuery(name = "Projekty.findByCzasTrwania", query = "SELECT p FROM Projekty p WHERE p.czasTrwania = :czasTrwania")
    , @NamedQuery(name = "Projekty.findByDataG\u0142osowania", query = "SELECT p FROM Projekty p WHERE p.dataG\u0142osowania = :dataG\u0142osowania")})
public class Projekty implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_P")
    private Long idP;
    @Size(max = 200)
    @Column(name = "NAZWA")
    private String nazwa;
    @Size(max = 300)
    @Column(name = "OPIS")
    private String opis;
    @Size(max = 50)
    @Column(name = "DZIELNICA")
    private String dzielnica;
    @Column(name = "KOSZT")
    private Integer koszt;
    @Size(max = 50)
    @Column(name = "CZAS_TRWANIA")
    private String czasTrwania;
    @Size(max = 50)
    @Column(name = "DATA_G\u0141OSOWANIA")
    private String dataGłosowania;
    @OneToMany(mappedBy = "idP")
    private List<Głosy> głosyList;
    @OneToMany(mappedBy = "idP")
    private List<Operacje> operacjeList;
    @OneToMany(mappedBy = "idP")
    private List<Załączniki> załącznikiList;
    @OneToMany(mappedBy = "idP")
    private List<Wyniki> wynikiList;
    @Column(name = "CZY_ZAKO\u0144CZONY")
    private Boolean czyZakończony;
    @Column(name = "CZY_WPROWADZONY")
    private Boolean czyWprowadzony;

    public Projekty() {
    }

    public Projekty(Long idP) {
        this.idP = idP;
    }

    public void setProjekt(String nazwa, String opis, String dzielnica, Integer koszt, String czasTrwania, String dataGlosowania, Boolean czyZakonczony, Boolean czyWprowadzony) {
        this.nazwa = nazwa;
        this.opis = opis;
        this.dzielnica = dzielnica;
        this.koszt = koszt;
        this.czasTrwania = czasTrwania;
        this.dataGłosowania = dataGlosowania;
        this.czyZakończony = czyZakonczony;
        this.czyWprowadzony = czyWprowadzony;
    }
    
    public Long getIdP() {
        return idP;
    }

    public void setIdP(Long idP) {
        this.idP = idP;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }
    
    public String getOpis() {
        return opis;
    }

    public void setOpis(String opis) {
        this.opis = opis;
    }

    public String getDzielnica() {
        return dzielnica;
    }

    public void setDzielnica(String dzielnica) {
        this.dzielnica = dzielnica;
    }

    public Integer getKoszt() {
        return koszt;
    }

    public void setKoszt(Integer koszt) {
        this.koszt = koszt;
    }

    public String getCzasTrwania() {
        return czasTrwania;
    }

    public void setCzasTrwania(String czasTrwania) {
        this.czasTrwania = czasTrwania;
    }

    public String getDataGłosowania() {
        return dataGłosowania;
    }

    public void setDataGłosowania(String dataGłosowania) {
        this.dataGłosowania = dataGłosowania;
    }

    public Boolean getCzyZakonczony() {
        return czyZakończony;
    }
    
    public void setCzyZakończony(Boolean czyZakończony) {
        this.czyZakończony = czyZakończony;
    }
    
    public Boolean getCzyWprowadzony() {
        return czyWprowadzony;
    }

    public void setCzyWprowadzony(Boolean czyWprowadzony) {
        this.czyWprowadzony = czyWprowadzony;
    }
    
    @XmlTransient
    public List<Głosy> getGłosyList() {
        return głosyList;
    }

    public void setGłosyList(List<Głosy> głosyList) {
        this.głosyList = głosyList;
    }

    @XmlTransient
    public List<Operacje> getOperacjeList() {
        return operacjeList;
    }

    public void setOperacjeList(List<Operacje> operacjeList) {
        this.operacjeList = operacjeList;
    }

    @XmlTransient
    public List<Załączniki> getZałącznikiList() {
        return załącznikiList;
    }

    public void setZałącznikiList(List<Załączniki> załącznikiList) {
        this.załącznikiList = załącznikiList;
    }

    @XmlTransient
    public List<Wyniki> getWynikiList() {
        return wynikiList;
    }

    public void setWynikiList(List<Wyniki> wynikiList) {
        this.wynikiList = wynikiList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idP != null ? idP.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Projekty)) {
            return false;
        }
        Projekty other = (Projekty) object;
        if ((this.idP == null && other.idP != null) || (this.idP != null && !this.idP.equals(other.idP))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminne.Encje.Projekty[ idP=" + idP + " ]";
    }
    
}
