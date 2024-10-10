export interface Produto {
  id: number;
  nome: string;
  preco: number;
  categoriaId: number;
}

export interface Categoria {
  id: number;
  nome: string;
  produtos: Produto[];
}