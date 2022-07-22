import { Component, OnInit } from '@angular/core';
import { Player } from '../models/Player';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.css']
})
export class RankingComponent implements OnInit {
  players!: Player[];
  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.loadPlayers();
  }

  loadPlayers() {
    this.playerService.getPlayers().subscribe(players => this.players = players);
  }
}
