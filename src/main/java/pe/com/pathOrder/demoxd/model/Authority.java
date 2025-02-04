package pe.com.pathOrder.demoxd.model;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.UniqueConstraint;

import pe.com.pathOrder.demoxd.model.Usuario;

@Entity
@Table(name = "authorities",uniqueConstraints = { @UniqueConstraint(columnNames = { "user_id", "authority" }) })
public class Authority {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private long id;
	
	@Column(length = 30, nullable = false)
	private String authority;
	
	@ManyToOne(cascade = CascadeType.ALL)
	@JoinColumn(name = "user_id")
	private Usuario usuario;
	
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public String getAuthority() {
		return authority;
	}
	public void setAuthority(String authority) {
		this.authority = authority;
	}
	public Usuario getUsuario() {
		return usuario;
	}
	public void setUsuario(Usuario usuario) {
		this.usuario = usuario;
	}
	
}
