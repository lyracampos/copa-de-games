import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Campeonato } from 'src/app/models/campeonato.model';
import { CampeonatoService } from 'src/app/services/campeonato.service';

@Component({
  selector: 'app-resultado-final',
  templateUrl: './resultado-final.component.html',
  styleUrls: ['./resultado-final.component.css']
})

export class ResultadoFinalComponent implements OnInit {

  public campeonato: Campeonato;

  constructor(private campeonatoService: CampeonatoService, private actRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.buscarCampeonato();
  }

  buscarCampeonato(): void{
    this.campeonatoService.buscarCampeonato(this.actRoute.snapshot.params.id).subscribe(
      resp => { this.campeonato = resp; },
      error => { console.log(error); });
  }
}
