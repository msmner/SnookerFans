import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Player } from '../../models/Player';
import { PlayerService } from '../../services/player.service';

@Component({
  selector: 'app-player-card',
  templateUrl: './player-card.component.html',
  styleUrls: ['./player-card.component.css']
})
export class PlayerCardComponent implements OnInit {
@Input() player!: Player;
  constructor(private playerService: PlayerService, private router: Router) { }

  ngOnInit(): void {
  }

  delete(){
    this.playerService.deletePlayer(this.player.userName).subscribe({
      complete: () => this.router.navigateByUrl('')
    });
  }
}
