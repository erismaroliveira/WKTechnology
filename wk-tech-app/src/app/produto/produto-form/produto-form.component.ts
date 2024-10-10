import { Component, inject, OnInit } from '@angular/core';
import { Produto } from '../../shared/models/produto.model';
import { ProdutoService } from '../../shared/services/produto.service';
import { CategoriaService } from '../../shared/services/categoria.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Categoria } from '../../shared/models/categoria.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-produto-form',
  standalone: true,
  imports: [FormsModule, RouterModule],
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.scss'],
})
export class ProdutoFormComponent implements OnInit {
  produto: Produto = { id: 0, nome: '', descricao: '', preco: 0, categoriaId: 0 };
  categorias: Categoria[] = [];

  protected router = inject(Router);
  private produtoService = inject(ProdutoService);
  private categoriaService = inject(CategoriaService);
  private activatedRoute = inject(ActivatedRoute);

  ngOnInit(): void {
    this.categoriaService.getAllCategorias().subscribe((data) => {
      this.categorias = data;
    });

    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.produtoService.getProdutoById(+id).subscribe((data) => {
        this.produto = data;
      });
    }
  }

  salvar(): void {
    if (this.produto.id) {
      this.produtoService.updateProduto(this.produto).subscribe(() => {
        Swal.fire({
          title: 'Produto Editado!',
          text: 'O produto foi editado com sucesso.',
          icon: 'success',
          confirmButtonColor: '#3085d6',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/produtos']);
        });
      });
    } else {
      this.produtoService.createProduto(this.produto).subscribe(() => {
        Swal.fire({
          title: 'Produto Adicionado!',
          text: 'O produto foi adicionado com sucesso.',
          icon: 'success',
          confirmButtonColor: '#3085d6',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/produtos']);
        });
      });
    }
  }
}
