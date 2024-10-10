import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../../shared/services/categoria.service';
import { Router } from '@angular/router';
import { Categoria } from '../../shared/models/categoria.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-categoria-list',
  standalone: true,
  imports: [],
  templateUrl: './categoria-list.component.html',
  styleUrl: './categoria-list.component.scss'
})
export class CategoriaListComponent implements OnInit {
  categorias: Categoria[] = [];

  constructor(private categoriaService: CategoriaService, private router: Router) {}

  ngOnInit(): void {
    this.loadCategorias();
  }

  loadCategorias(): void {
    this.categoriaService.getAllCategorias().subscribe((data) => {
      this.categorias = data;
    });
  }

  adicionarCategoria(): void {
    this.router.navigate(['/categorias/novo']);
  }

  editarCategoria(id: number): void {
    this.router.navigate(['/categorias/editar', id]);
  }

  excluirCategoria(id: number): void {
    this.categoriaService.deleteCategoria(id).subscribe(() => {
      Swal.fire(
        'Excluído!',
        'A categoria foi excluída com sucesso.',
        'success'
      );
      this.loadCategorias();
    }, (error) => {
      console.error('Erro ao excluir a categoria', error);
    });
  }

  confirmDelete(id: number): void {
    Swal.fire({
      title: 'Você tem certeza?',
      text: 'Esta ação não poderá ser desfeita!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.excluirCategoria(id);
      }
    });
  }
}
