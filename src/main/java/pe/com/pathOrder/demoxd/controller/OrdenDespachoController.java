package pe.com.pathOrder.demoxd.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.SessionAttributes;

import pe.com.pathOrder.demoxd.service.OrdenDespachoService;

@Controller
@RequestMapping("/OrdenDespacho")
public class OrdenDespachoController {
	//@Autowired
	//private OrdenDespachoService ordenDespachoService;
	
	@GetMapping("inicio")
	public String inicio(Model model) {
		String nombre = "Josealdo :v";
		model.addAttribute("nombre2", nombre);
		return "OrdenDespacho/inicio";
	}
	
}
