<script setup>
import BarChart from "./BarChart.vue";
import Map from "./Map.vue";

const samp_dat = [
	{
		"bbl": 10,
		"boroughNumber": 1,
		"buildingName": "100 Gold St",
		"buildingAddress": "100 Gold St ",
		"borough": "Manhattan",
		"state": "New York",
		"postcode": 10038,
		"block": 94,
		"lot": 25,
		"energyUsage": 64582,
		"latitude": 40.710353,
		"longitude": -74.004007,
		"communityBoard": 1,
		"councilDistrict": 1,
		"censusTract": 1501,
		"bin": 1001289,
		"nta": "Battery Park City-Lower Manhattan                                          "
	},
	{
		"bbl": 1000940025,
		"boroughNumber": 1,
		"buildingName": "100 Gold St",
		"buildingAddress": "100 Gold St ",
		"borough": "Manhattan",
		"state": "New York",
		"postcode": 10038,
		"block": 94,
		"lot": 25,
		"energyUsage": 64582,
		"latitude": 40.710353,
		"longitude": -74.004007,
		"communityBoard": 1,
		"councilDistrict": 1,
		"censusTract": 1501,
		"bin": 1001289,
		"nta": "Battery Park City-Lower Manhattan                                          "
	},
	{
		"bbl": 1001210001,
		"boroughNumber": 1,
		"buildingName": "Manhattan Municipal Building",
		"buildingAddress": "1 Centre St ",
		"borough": "Manhattan",
		"state": "New York",
		"postcode": 10007,
		"block": 121,
		"lot": 1,
		"energyUsage": 92117,
		"latitude": 40.713001,
		"longitude": -74.004181,
		"communityBoard": 1,
		"councilDistrict": 1,
		"censusTract": 29,
		"bin": 1001394,
		"nta": "Chinatown                                                                  "
	},
	{
		"bbl": 1001220001,
		"boroughNumber": 1,
		"buildingName": "Tweed Courthouse (DOE Offices)",
		"buildingAddress": "52 Chambers St ",
		"borough": "Manhattan",
		"state": "New York",
		"postcode": 10007,
		"block": 122,
		"lot": 1,
		"energyUsage": 15308,
		"latitude": 40.713814,
		"longitude": -74.005570,
		"communityBoard": 1,
		"councilDistrict": 1,
		"censusTract": 31,
		"bin": 1079146,
		"nta": "SoHo-TriBeCa-Civic Center-Little Italy                                     "
	},
	{
		"bbl": 1001347501,
		"boroughNumber": 1,
		"buildingName": "Home Life Building",
		"buildingAddress": "253 Broadway ",
		"borough": "Manhattan",
		"state": "New York",
		"postcode": 10007,
		"block": 134,
		"lot": 7501,
		"energyUsage": 19284,
		"latitude": 40.713265,
		"longitude": -74.007063,
		"communityBoard": 1,
		"councilDistrict": 1,
		"censusTract": 21,
		"bin": 1082757,
		"nta": "SoHo-TriBeCa-Civic Center-Little Italy                                     "
	},
	{
		"bbl": 1001530001,
		"boroughNumber": 1,
		"buildingName": "Sun Building",
		"buildingAddress": "280 Broadway ",
		"borough": "Manhattan",
		"state": "New York",
		"postcode": 10007,
		"block": 153,
		"lot": 1,
		"energyUsage": 16423,
		"latitude": 40.714417,
		"longitude": -74.006089,
		"communityBoard": 1,
		"councilDistrict": 1,
		"censusTract": 31,
		"bin": 1079215,
		"nta": "SoHo-TriBeCa-Civic Center-Little Italy                                     "
	}]

const highestUse = samp_dat.reduce(function (prev, current) {
	return (prev.energyUsage > current.energyUsage) ? prev : current
})

const lowestUse = samp_dat.reduce(function (prev, current) {
	return (prev.energyUsage < current.energyUsage) ? prev : current
})

</script>

<template>
	<div class="dashboard">
		<h1>Dashboard</h1>
		<div class="grid-container">
			<div class="grid-item grid-item1">
				<BarChart></BarChart>
			</div>
			<div class="grid-item grid-item3">Grid </div>
			<div class="grid-item grid-item2">
				<Map></Map>
			</div>
			<div class="grid-item highestUser">
				<div class="card w-100 border-danger summary">
					<div class="card-header">
						Highest Energy Usage
					</div>
					<div class="card-body">
						<h5 class="card-title">{{ highestUse.buildingName }}</h5>
						<h6 class="card-text text-danger">{{ highestUse.energyUsage }}</h6>
						<a href="#" class="btn btn-primary">See more info</a>
					</div>
				</div>				
				
			</div>
			
			<div class="grid-item grid-item5">
				<div class="card  w-100 summary border-success ">
					<div class="card-header">
						Lowest Energy Usage
					</div>
					<div class="card-body">
						<h5 class="card-title">{{ lowestUse.buildingName }}</h5>
						<h6 class="card-text text-success">{{ lowestUse.energyUsage }}</h6>
						<a href="#" class="btn btn-primary">See more info</a>
					</div>
				</div>
			</div>
			<div class="grid-item grid-item6">Grid 2</div>
			<div class="grid-item grid-item7">Grid 2</div>
		</div>
	</div>
</template>


<style>
.highestUser {}

.grid-container {
	display: grid;
	grid-template-columns: 1fr 1fr 1fr;
	grid-auto-rows: minmax(150px, auto);
	grid-gap: 10px;
	width: 100%;

}

.dashboard {
	width: 100%;
}

.grid-item {
	background-color: aquamarine;
	border-style: solid;
}

/* .grid-item2 {
        grid-column-start: 2;
        grid-column-end: 3;

        grid-row-start: 1;
        grid-row-end: 3;
    } */
.grid-item7 {
	grid-column-start: 1;
	grid-column-end: -1;
}

.grid-item1 {
	background-color: white;
}
</style>