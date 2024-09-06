import { Component, OnInit } from '@angular/core';
import { SaldoDiario } from '../../models/saldoDiario';
import { RelatorioService } from '../../services/relatorio.service';

@Component({
  selector: 'app-relatorio',
  templateUrl: './relatorio.component.html',
  styleUrls: ['./relatorio.component.scss']
})
export class RelatorioComponent {
  dataSelecionada: string | null = null;
  saldoConsolidado: SaldoDiario = new SaldoDiario();
  errorMessage: string | null = null;

  constructor(private relatorioService: RelatorioService) { }

  ngOnInit(): void {
  }

  onBuscarRelatorio(): void {
    if (this.dataSelecionada) {
      this.relatorioService.getExtractByDate(this.dataSelecionada)
        .subscribe(
          (response: SaldoDiario) => {
            this.saldoConsolidado = response;
            this.errorMessage = null;
          },
          (error) => {
            this.errorMessage = 'Erro ao buscar o relatório. Verifique a data e tente novamente.';
            this.saldoConsolidado = new SaldoDiario();
          }
        );
    }
  }

  formatCurrency(value: number): string {
    return value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
  }
}
