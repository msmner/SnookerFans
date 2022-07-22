import { Component, OnInit } from '@angular/core';
import { Player } from '../../models/Player';
import { PlayerService } from '../../services/player.service';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {
players: Player[] = [];
  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.loadPlayers();
  }

  loadPlayers() {
    this.playerService.getPlayers().subscribe((players: Player[]) => {
      this.players = players;
    })
  }
}
