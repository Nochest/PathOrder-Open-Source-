package pe.com.pathOrder.model;

import java.util.List;

public class OrdenDespacho {
	Integer id;
	String numeroOrden;
	String prioridad;
	String AWB_BL;
	String AWB_BL_Origen;
	String origen;
	Integer cantidadSeries;
	Integer cantidadBultos;
	
	Canal canal;
	TipoDespacho tipoDespacho;
	Proveedor proveedor;
	
	List<Bulto> bultos;
	List<Factura> facturas;
	
	String observacion;
	
}
