import { Component, inject, OnInit } from '@angular/core';
import { Categoria, Produto } from '../../shared/models/categoria.model';
import { CategoriaService } from '../../shared/services/categoria.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-categoria-form',
  standalone: true,
  imports: [FormsModule, RouterModule],
  templateUrl: './categoria-form.component.html',
  styleUrl: './categoria-form.component.scss'
})
export class CategoriaFormComponent implements OnInit {

  categoria: Categoria = { id: 0, nome: '', produtos: [] };
  produtos: Produto[] = [];
  categorias: Categoria[] = [];

  protected router = inject(Router);
  private categoriaService = inject(CategoriaService);
  private activatedRoute = inject(ActivatedRoute);

  constructor() {}

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.categoriaService.getCategoriaById(+id).subscribe((data) => {
        this.categoria = data;
      });
    }
  }

  salvar(): void {
    if (this.categoria.id) {
      this.categoriaService.updateCategoria(this.categoria).subscribe(() => {
        Swal.fire({
          title: 'Categoria Editada!',
          text: 'A categoria foi editada com sucesso.',
          icon: 'success',
          confirmButtonColor: '#3085d6',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/categorias']);
        });
      });
    } else {
      this.categoriaService.createCategoria(this.categoria).subscribe(() => {
        Swal.fire({
          title: 'Categoria Adicionada!',
          text: 'A categoria foi adicionada com sucesso.',
          icon: 'success',
          confirmButtonColor: '#3085d6',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/categorias']);
        });
      });
    }
  }
}
