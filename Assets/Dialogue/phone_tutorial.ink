VAR delay = 3
VAR shift_end = 3
//new guy whats up!
//first draft done 4/4/26


// game loads into the first day, starting in the map view. In the top right corner is the settings button and the clock.
=== start ===
Welcome to your first day on the job. I'm your boss and I'll be helping you get situated. #PHONE #{delay}
Looks like you already found the map! This is your assigned neighborhood for today. #PHONE #{delay}
There is also a clock with the date and time, shown on the top right of the screen. Your shift ends at {shift_end}am. #PHONE #{delay}
If you need to take a break or change any settings, that's the button next to the clock. #PHONE #{delay}

Every day the neighborhood you watch over will be a little different— but it's all the same procedure. #PHONE #{delay}
Your job is to keep the vampires in check while they do their rounds. You're part of the watch team, so when you see something illegal happening it's your duty to report it. #PHONE #{delay}
You'll be able to see vampires roam around in real time. When an interaction starts between a vampire and a villager, you'll see a "!" on the map. #PHONE #{delay}

//exclaimation point appears

Oh, looks like something is happening right now. I'll walk you through your first interaction. #PHONE #{delay}
Use the mouse to click on the "!" and the map will automatically zoom in for you to watch. #PHONE #{delay}

//start scenario. The map is now a minimap underneath the clock, and the right side of the screen is clear so that the warrants can be shown. Also, there should be a handbook of the vampire code that maybe includes brief notes on the hints given in the tutorial) somewhere on the right side too. When you click it, I imagine it would open up and take up just the right side. In the top left, is the report button. 

You can see the vampire at the door right? It's very common for a vampire to try and trick people into letting them into their private property. #PHONE #{delay}
Let's see what this one tries to do. #PHONE #{delay}

//scenario plays dialogue, stops when warrant gets presented. (invalid warrant! date/address wrong)

If there is a document being presented, you should be able to see it on the right side. This is a search warrant. #PHONE #{delay}
Well, it is SUPPOSED to be a search warrant, but it looks like there are a few mistakes on it which makes it an invalid legal document. #PHONE #{delay}
According to vampire code, if they do not have a legal search warrant then they cannot enter someone's home without consent. #PHONE #{delay}
I'll point out the mistakes for you, to get you started. #PHONE #{delay}

//highlight the date

A valid search warrant must have the correct date. This document was only valid for yesterday. #PHONE #{delay}

//highlight the address

The address of the property should also be correct. They have the wrong street name written. #PHONE #{delay}

//highlight the signature

This signature here is by a magistrate, or a judge, of the court. This is actually correct, but I just wanted to point out that if a search warrant is signed by anyone other than a judge, it is not valid. #PHONE #{delay}

//hightlights go away

So, do you see why this document is invalid? The date and the address are wrong. If even one thing is incorrect, then it cannot be legally used to enter the house. #PHONE #{delay}
Let's keep watching. No crime has occured so far, because the vampire has not acted on the false warrant yet; they've only presented it. Just presenting an invalid warrant is still legal. #PHONE #{delay}

//scene plays out until the vampire tries to break in without consent. As this is happening, the texts continue.

Are you seeing what I'm seeing? This person clearly stated they did not consent to a search. Since the search warrant is invalid, this is now an unlawful entry into the home. #PHONE #{delay}

///////////// THIS SECTION DOES NOT INCLUDE THE "BURST INTO FLAMES" OPTION
///////////// (if we add this feature, just reword stuff after this to include it)

Now we're at the part of your job where you have to make a choice. Do you see the red icon in the top left of the screen? #PHONE #{delay}
That's the report function. When you are watching an interaction, you can report the involved vampire at any time. Don't use it if the vampire doesn't break code. #PHONE #{delay}
We use these reports to keep track of violations from vampires; if you falsely report someone it could mess up our data. We want to eventually change some of the outdated rules in the vampire code, so we need it to be as accurate as possible. #PHONE #{delay}
Back to the situation: the choice you need to make should be clear. Go ahead and report the vampire. #PHONE #{delay}

//does the game wait for you to report, or can you fail the tutorial!? hahaha thatd be funny (not gonna do that now though)

Very good. I knew you would be right for this job. #PHONE #{delay}
Now that the report has been submitted, it will be reviewed along with any additional reports you submit during your shift. You can check them later when you're done. #PHONE #{delay}
Unfortunately, we can't actively intervene when we see an illegal scenario like this taking place. It sucks— but that's why we are trying to change the vampire code: to help protect these villagers from being wronged. #PHONE #{delay}
Keep your eyes peeled. I'm hopeful that you can get some good work done for the community. I think you can handle the rest on your own for today. #PHONE #{delay}

Oh, almost forgot.. incidents don't wait for you to finish the previous one. If another situation appears which might require your action, you'll see it on the minimap. You can click the minimap to go back into the full map view. #PHONE #{delay}
You may need to juggle more than one scenario at a time. Just remember that all documents you have access to are only for the situation you're focused on. I trust you won't confuse them. #PHONE #{delay}
If you leave a scenario before it ends to check on another one, don't worry. You will still be able to go back to it, but remember that it's in real-time; things may happen while you're not watching. #PHONE #{delay}

Okay, I hope you caught all of that. If there's anything you forget, check the handbook. It's on the right. Good luck! #PHONE #{delay}
-> END
//end tutorial.


