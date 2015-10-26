﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication3.PL;
using WindowsFormsApplication3.DAL;
namespace WindowsFormsApplication3.BL
{
    class Game
    {
        public Game(){

           create_deck_of_cards(CARD_NAMES);

            foreach (var item in deck_of_cards)
            {
                // Console.Write(item + "\n");
            }
        }
      List<string> CARD_NAMES = new List<string>()  {
	                                "8-ball",
	                                "baked-potato",
	                                "dinosaur",
	                                "kronos",
	                                "rocket",
	                                "skinny-unicorn",
	                                "that-guy",
	                                "zeppelin"
                                  };
     
        public List<string> deck_of_cards = new List<string>();
        private  void create_deck_of_cards(List<string> card_names)
        {

            List<string> possible_cards = new List<string>();

            // loop through card_names and add each card twice to a temporary array (possible_cards)
            for (var i = 0; i < card_names.Count; i++)
            {
                possible_cards.Add(card_names[i]);
                possible_cards.Add(card_names[i]);
            }
            // loop through possible_cards
            for (var i = 0; i < 16; i++)
            {
                // generate random index to pick a random card from possible_cards
                var possible_rand = new Random().Next(possible_cards.Count);
                // add the picked card to deck_of_cards
                deck_of_cards.Add(possible_cards[possible_rand]);
                // remove the selected card from possible_cards
                possible_cards.Remove(possible_cards[possible_rand]);

            }

        }



        public List<string> name_card = new List<string>();
        public bool  check_card()
        {
            if (name_card.Count == 2)
            {
                if (name_card[0] == name_card[1])
                {
                   //score  ++
                    Player.score+=10;
                    Player.answer--;
                    affich(false, null, null);
                    if (Player.answer <= 1)
                    {
                         affich(true,"Gagne  ", "Hey " + Player.naam + "jeej je bent gewonnen");
                    }
                    name_card.RemoveRange(0, 2);
                    return false;
                }
                else
                {
                    Player.error --;
                    affich(false, null, null);
                    if (Player.error == 0)
                    {
                       
                        affich(true,"Game over ", "Hey " + Player.naam + "je bent verloren");
                    }
                    name_card.RemoveRange(0, 2);
                    return true;
                  
                }
               
            }
           
            return false ;
        }


        private void affich(bool cas ,string title ,string msg)
        {
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                var frm = (System.Windows.Forms.Application.OpenForms["Form1"] as Form1);
                if (cas)
                {
                    frm.deleteMemory();
                    frm.deleteScore();
                    frm.addResult();
                    frm.result.lblTitle.Text = title;
                    frm.result.lblMessage.Text = msg;
                }
                else
                {
                    frm.new_score.lblScore.Text = Player.score.ToString();
                    frm.new_score.lblError.Text = Player.error.ToString();
                }
              
            }  
        }
        public void replay()
        {
            Player.error = 10;
            Player.answer = 8;
            Player.score = 0;
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                var frm = (System.Windows.Forms.Application.OpenForms["Form1"] as Form1);
                frm.deleteResult();
                frm.addMemory();
                frm.addScore();
                frm.new_score.lbl1.Text = Player.naam;
                frm.new_score.lbl2.Text = Player.score.ToString();
                frm.new_score.lbl3.Text = Player.error.ToString();
            }
        }
    }
}
