import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Player } from 'src/app/models/Player';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-update-player',
  templateUrl: './update-player.component.html',
  styleUrls: ['./update-player.component.css']
})
export class UpdatePlayerComponent implements OnInit {
  player!: Player;
  playerForm!: FormGroup;

  constructor(private fb: FormBuilder, private playerService: PlayerService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadPlayer();
    this.initializeForm();
    //this.prefillForm();
  }

  initializeForm() {
    this.playerForm = this.fb.group({
      username: ['', Validators.required],
      nationality: ['', [Validators.required]],
      description: ['', [Validators.required]],
    })


  }

  loadPlayer() {
    this.playerService.getPlayer(this.activatedRoute.snapshot.paramMap.get('username')!).subscribe(player => {
      this.player = player;
      this.playerForm.get('username')!.setValue(this.player.userName);
      this.playerForm.get('nationality')!.setValue(this.player.nationality);
      this.playerForm.get('description')!.setValue(this.player.description);
    });
  }

  update() {
    this.playerService.updatePlayer(this.player.userName, this.playerForm.value).subscribe({
      complete: () => this.router.navigateByUrl('/players')
    })
  }
}
