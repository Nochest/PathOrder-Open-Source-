package pe.com.pathOrder.model;

import java.util.Date;
import java.util.List;

public class Factura {
	private Integer id;
	private String numFactura;
	private String descrpicion;
	private Integer unidad;
	private Date fecha;
	
	private OrdenDespacho ordenDespacho;
	
	private List<FacturaMercaderia> facturasMercaderias;
}
	