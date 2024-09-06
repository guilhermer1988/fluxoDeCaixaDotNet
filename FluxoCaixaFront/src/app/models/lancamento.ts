export class Lancamento {
    id!: number;
    tipo!: TipoEnum;
    valor!: number;
    data!: string;// ISO date string
    descricao!: string;
  }

  export enum TipoEnum
  {
    Debito,
    Credito
  }
  