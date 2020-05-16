Orbitality

Controls:

You need to hold left mouse button to make shot in cursor dirraction.
There is 0.5sec delay int shot power controlling, it means that if you release mouse button earlier, the speed of shot is less;

Technical details:

There is implemented custom physics in PhysicsController. it calculates all static(planets and sun) and dynamic(rockets) to make space bullet physics.

Planets being moved by MovementsController. it evaluate planets position due to lifetime, speed,
and distance to sun that means that planets dont moves by physics. This dessision helps make save/load process.

WorldManager creates the world depends on WorldState for both creation ar loading world.


The AI calculations of shoting being controlled by AIWeaponController.
It calculates in background thread the dirraction of shoting and little compensation to avoid bullet-sun collision.
I could make the cheating ai to calculate the rigth rtajectory of bullet to hit target in 100% but it will be unplayable.
And i think it would be better to make ai with UnityML but creating this type of AI takes much more time.