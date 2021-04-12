import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  constructor() { }

  public ngOnInit() {

    $().ready(function(){
      $("btn").click(function(){
          var div = $("div");
          div.animate({left: '100px'}, "slow");
          div.animate({fontSize: '5em'}, "slow");
      });
  });
  }




}
