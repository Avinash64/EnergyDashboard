<script setup>
import {ref, onMounted, computed, watch} from 'vue';
const b_num = ref('0')

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
</script>


<template>
    <div class="buildingsPage">
        <h1>Buildings</h1>
        <button @click="b_num++">Add</button>
        <div class="list-group">

            <div class="building_list_item list-group-item">
                <div class="field">BBL</div>
                <div class="field">Name</div>
                <div class="field">Borough</div>
                <div class="field">Building Address</div>
                <div class="field">Energy Usage</div>
                <div class="">Details</div>
            </div>  
            <div v-for="building, index in samp_dat" :key="index" >
                <div class="building_list_item list-group-item" :class="index % 2 == 0 && 'odd'">
                    <div class="field">{{ building.bbl }} {{ index }}</div>
                    <div class="field">{{ building.buildingName }}</div>
                    <div class="field">{{ building.borough }}</div>
                    <div class="field">{{ building.buildingAddress }}</div>
                    <div class="field">{{ building.energyUsage }}</div>
                    <a :href="`/buildings/${building.bbl}`">Details</a>
                </div>    
            </div>
        </div>

    {{ b_num }}
  </div>
</template>



<style scoped>
    .building_list_item {
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: space-between;
        width: 100%;
        /* margin-bottom: 5px; */
    }
    .field {
        width: 18%;
    }

    .buildingsPage{
        width: 100%;
    }

    .odd {
        background-color: aqua;
    }
</style>

