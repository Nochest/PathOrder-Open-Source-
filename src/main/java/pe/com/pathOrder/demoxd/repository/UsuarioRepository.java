package pe.com.pathOrder.demoxd.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import pe.com.pathOrder.demoxd.model.Usuario;

public interface UsuarioRepository extends JpaRepository<Usuario, Long>{
	Optional<Usuario> findByUsername(String username);

}
