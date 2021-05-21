# Loads the dependencies:
LoadPackage("Float");
SetFloats(MPC);

LucyAndLilyFlip := function(direction, piece) # piece = rec(location, order, root, orientation:= [a,b])
	local d, conjugate, buildShiftSummand,
	newOrientation, newLocation, locationFloat,
	output;

	d := direction + piece.orientation[2]; # Assume direction is scrubbed for now. 

	conjugate := piece.orientation[1] = 1;

	buildShiftSummand := 
		function(d, N, con)
			local product;
			product := E(2*N)^(2*d+1);
			if con then
				product := -product^-1;
			fi;
			product := product * (E(2*N) + E(2*N)^-1);
			return product;
		end;
	# assigned;

	newLocation := piece.location + buildShiftSummand(d, piece.order, conjugate);
	newOrientation := [];
	newOrientation[1] := 1 - piece.orientation[1];
	newOrientation[2] := (-2 * d - 1 + piece.orientation[2] + 3*piece.order) mod piece.order;

	locationFloat := Float(newLocation);
	output := rec(location:= newLocation,
		   		  order := piece.order,
		   		  orientation:= newOrientation,
				  coordinates := rec(
					  real:= RealPart(locationFloat),
					  imag:= ImaginaryPart(locationFloat)
					 ),
				  norm:= Norm(locationFloat)
			 	 );

	return output;
end;
