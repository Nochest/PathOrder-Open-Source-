package pe.com.pathOrder.model;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
@Entity
@Table(name="tipo_despacho")
public class TipoDespacho {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer id;
	@Column(name = "nombre", length = 50, nullable = false)
	private String nombre;
	@OneToMany(mappedBy = "tipo_despacho")
	private List<OrdenDespacho> ordenesDespacho;
	
	public TipoDespacho() {
		this.ordenesDespacho = new ArrayList<>();
	}

	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public List<OrdenDespacho> getOrdenesDespacho() {
		return ordenesDespacho;
	}

	public void setOrdenesDespacho(List<OrdenDespacho> ordenesDespacho) {
		this.ordenesDespacho = ordenesDespacho;
	}
	
	
}
