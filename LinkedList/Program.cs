using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace LinkedList
{

    class Solution
    {

        // Each node in the linked list is of type Song
        class Song
        {
            public string title;
            public Song nextSong;
            public Song prevSong;

            //constructor
            public Song(string title)
            {
                this.title = title;
                this.nextSong = null;
                this.prevSong = null;
            }
        }

        // Play list is linked list of songs
        class PlayList
        {
            public Song firstSong;
            public Song lastSong;
            //empty constructor
            public PlayList()
            {
                this.firstSong = null;
                this.lastSong = null;
            }
            public void AddSong(string title)
            {
                //Instantiate class Song by calling constructor
                Song newSong = new Song(title);


                if (this.firstSong == null) // playlist is empty
                {
                    this.firstSong = newSong;
                }
                else // playlist is not empty; attach new Song to the lastSong
                {
                    this.lastSong.nextSong = newSong;
                    newSong.prevSong = this.lastSong;
                }
                // make new song the lastSong
                this.lastSong = newSong;
            }

            public void PrintSongs()
            {
                //this refers to the instance of the PlayList class in which the PrintSongs() method is invoked
                if (this.firstSong == null)
                {
                    Console.WriteLine("Playlist is empty");
                    return;
                }

                Song currSong = this.firstSong;//while firstSong in playList is not null
                while (currSong != null)
                {
                    Console.WriteLine("Title : " + currSong.title);
                    //if (currSong.prevSong != null)
                    //{
                    //    Console.WriteLine("Previous Song: " + currSong.prevSong.title);
                    //}
                    if (currSong.nextSong != null)
                    {
                        Console.WriteLine("    next song : " + currSong.nextSong.title);
                    }
                    Console.WriteLine();
                    currSong = currSong.nextSong;//move on to the next song to traverse through the list and get all titles of song

                }
            }
 
            public int Length()
            {
                Song currSong = this.firstSong;
                var count = 0;
                while (currSong != null)
                {                   
                    count++;
                    currSong = currSong.nextSong;//traverse through the list until null is reached
                }
                return count;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Creating new playlist");
            Console.WriteLine();//new line
            var myPlaylist = new PlayList();//instantiating the class PlayList which will be empty the first time
            myPlaylist.AddSong("Humma Humma");
            myPlaylist.AddSong("Uyire Uyire");
            myPlaylist.AddSong("Kuchi Kuchi");
            var count = myPlaylist.Length();
            Console.WriteLine("Playlist created with " + count + " Songs");
            Console.WriteLine();//new line
            myPlaylist.PrintSongs();//prints out statements within the PrintSongs() method
        }
    }
}
