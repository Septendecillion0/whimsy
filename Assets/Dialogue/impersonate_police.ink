VAR delay = 3

A vampire dressed in local police department attire knocks on the front door of a house. #NARRATOR #{delay} 

Police! Open up! #VAMPIRE #{delay}
What!? Why is there a police officer here? I don't remember breaking any laws, what did I do? #VILLAGER #{delay}
There have been online threats from a user by the name of Phoenix. Ring any bells? #VAMPIRE #{delay}
What? I don't really post things online, and I've never heard of anyone named Phoenix either! #VILLAGER #{delay}
Don't play games with me! The messages came from an IP address located in this house. I have orders to take you in for questioning. Now, open this door! #VAMPIRE #{delay}
Eek! Don't you need to show me a paper or something? You can't come inside without one, right? #VILLAGER #{delay}
Fine. Happy? #VAMPIRE #WARRANT #{delay}

//shows warrant
{~ ->consent | ->no_consent}

==consent==
Oh.. okay, if it's a real warrant. I don't want to get in trouble. #VILLAGER #{delay}
    -> no_violation
= no_violation
The villager opens the door and allows the vampire in disguise to take them away. #NARRATOR #{delay}
Finally! Should've just let me in to start, villager. #VAMPIRE #{delay}
    ->END
    
==no_consent==
What? I—is that it? I don't even understand what it's saying! I won't let you in if I can't understand your papers. #VILLAGER #{delay}
{~ -> no_violation | ->violation}

= violation
The vampire forces the door open. #NARRATOR #{delay}
Just because you don't understand the law doesn't mean it doesn't apply to you. You're not safe with your ignorance. #VAMPIRE #{delay}
    ->END

= no_violation
The vampire forces the door open. #NARRATOR #{delay}
Just because you don't understand the law doesn't mean it doesn't apply to you. You're coming with me. #VAMPIRE #{delay}
    ->END
