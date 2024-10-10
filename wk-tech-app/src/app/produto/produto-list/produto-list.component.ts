import { Component, inject, OnInit } from '@angular/core';
import { ProdutoService } from '../../shared/services/produto.service';
import { Produto } from '../../shared/models/produto.model';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-produto-list',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.scss'],
})
export class ProdutoListComponent implements OnInit {
  produtos: Produto[] = [];
  private produtoService = inject(ProdutoService);

  constructor(private router: Router) {

  }

  ngOnInit(): void {
    this.loadProdutos();
  }

  loadProdutos(): void {
    this.produtoService.getAllProdutos().subscribe((data) => {
      this.produtos = data;
    });
  }

  adicionarProduto(): void {
    this.router.navigate(['/produtos/novo']);
  }

  editarProduto(id: number): void {
    this.router.navigate(['/produtos/editar', id]);
  }

  excluirProduto(id: number): void {
    this.produtoService.deleteProduto(id).subscribe(() => {
      Swal.fire(
        'Excluído!',
        'O produto foi excluído com sucesso.',
        'success'
      );
      this.loadProdutos();
    }, (error) => {
      console.error('Erro ao excluir o produto', error);
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
        this.excluirProduto(id);
      }
    });
  }
}
