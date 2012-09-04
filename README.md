# Inversion-of-control-vs-hand-rolled


This is the base code from the presentation.

It doesn't have either manual injection or IoC and is to be used as the base to move forwards from.

Feel free to fork the code and play with it as you wish but as this is *the* code for the presentation unfortunately I will not be accepting pull requests.

## Repo Structure

The code within the repo has been structured into 3 branches to provide sepearation between the 2 different approaches.

These are:

- master
- HandRolled
- IoC

### master

This is the code as it stood at the beginning of the presentation before either the manual or IoC injection was added

### HandRolled

This branch has all the changes, made chronologically, that were done in the presentation to enable dependency injection manually

### IoC

This branch has all the changes, again in chronological order, that were performed in the presentation to enable dependency injection using Ninject