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
@Table(name = "MIESZKA\u0143CY", catalog = "", schema = "IO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Mieszka\u0144cy.findAll", query = "SELECT m FROM Mieszka\u0144cy m")
    , @NamedQuery(name = "Mieszka\u0144cy.findByIdM", query = "SELECT m FROM Mieszka\u0144cy m WHERE m.idM = :idM")
    , @NamedQuery(name = "Mieszka\u0144cy.findByLogin", query = "SELECT m FROM Mieszka\u0144cy m WHERE m.login = :login")
    , @NamedQuery(name = "Mieszka\u0144cy.findByHas\u0142o", query = "SELECT m FROM Mieszka\u0144cy m WHERE m.has\u0142o = :has\u0142o")
    , @NamedQuery(name = "Mieszka\u0144cy.findByAdresEmail", query = "SELECT m FROM Mieszka\u0144cy m WHERE m.adresEmail = :adresEmail")
    , @NamedQuery(name = "Mieszka\u0144cy.findByCzyZag\u0142osowa\u0142", query = "SELECT m FROM Mieszka\u0144cy m WHERE m.czyZag\u0142osowa\u0142 = :czyZag\u0142osowa\u0142")})
public class Mieszkańcy implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "ID_M")
    private Long idM;
    @Size(max = 30)
    @Column(name = "LOGIN")
    private String login;
    @Size(max = 30)
    @Column(name = "HAS\u0141O")
    private String hasło;
    @Size(max = 50)
    @Column(name = "ADRES_EMAIL")
    private String adresEmail;
    @Column(name = "CZY_ZAG\u0141OSOWA\u0141")
    private Boolean czyZagłosował;
    @OneToMany(mappedBy = "idM")
    private List<Głosy> głosyList;

    public Mieszkańcy() {
    }

    public Mieszkańcy(Long idM) {
        this.idM = idM;
    }

    /**
     * Metoda umożliwiająca ustawienie wszystkich potrzebnych pól obiektu.
     * @param login - login konta mieszkańca
     * @param hasło - hasło konta miszkańca
     * @param adresEmail - adres email przypisany do konta mieszkańca
     * @param czyZagłosował - pole informujące czy mieszkaniec oddał już głos
     */
    public void setMieszkaniec(String login, String hasło, String adresEmail, Boolean czyZagłosował) {
        this.login = login;
        this.hasło = hasło;
        this.adresEmail = adresEmail;
        this.czyZagłosował = czyZagłosował;
    }
    
    public Long getIdM() {
        return idM;
    }

    public void setIdM(Long idM) {
        this.idM = idM;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getHasło() {
        return hasło;
    }

    public void setHasło(String hasło) {
        this.hasło = hasło;
    }

    public String getAdresEmail() {
        return adresEmail;
    }

    public void setAdresEmail(String adresEmail) {
        this.adresEmail = adresEmail;
    }

    public Boolean getCzyZagłosował() {
        return czyZagłosował;
    }

    public void setCzyZagłosował(Boolean czyZagłosował) {
        this.czyZagłosował = czyZagłosował;
    }

    @XmlTransient
    public List<Głosy> getGłosyList() {
        return głosyList;
    }

    public void setGłosyList(List<Głosy> głosyList) {
        this.głosyList = głosyList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idM != null ? idM.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Mieszkańcy)) {
            return false;
        }
        Mieszkańcy other = (Mieszkańcy) object;
        if ((this.idM == null && other.idM != null) || (this.idM != null && !this.idM.equals(other.idM))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ProjektyGminne.Encje.Mieszka\u0144cy[ idM=" + idM + " ]";
    }
    
}
