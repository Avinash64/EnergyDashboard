<script setup>
import BarChart from "./BarChart.vue";
import Map from "./Map.vue";
import { ref, onMounted, computed, watch, reactive } from 'vue';
const b_num = ref('0')

const samp_dat = ref([])
const highestUse = ref(null)
const lowestUse = ref(null)
const totalConsumption = ref(null)
const averageConsumption = ref(null)
onMounted(() => {
	const options = {
		method: 'GET',
		headers: {}
	};
	fetch('http://localhost:5156/api/stats/total', options)
		.then(response => response.json())
		.then(response => {
			console.log(response); totalConsumption.value = response
		})
	fetch('http://localhost:5156/api/stats/average', options)
		.then(response => response.json())
		.then(response => {
			console.log(response); averageConsumption.value = response
		})
	fetch('http://localhost:5156/api/stats/max', options)
		.then(response => response.json())
		.then(response => {
			console.log(response); highestUse.value = response
		})

		.catch(err => console.error(err));
	fetch('http://localhost:5156/api/stats/min', options)
		.then(response => response.json())
		.then(response => {
			console.log(response); lowestUse.value = response

		})
		.catch(err => console.error(err));

	fetch('http://localhost:5156/api/energy', options)
		.then(response => response.json())
		.then(response => {
			console.log(response); samp_dat.value = response

		})
		.catch(err => console.error(err));
})


</script>

<template>
	<div class="dashboard">
		<h1>Dashboard</h1>
		<div class="grid-container">
			<div class="grid-item grid-item1">
				<BarChart></BarChart>
			</div>


			<div v-if="totalConsumption" class="grid-item grid-item5">
				<div class="card  w-100 summary border-success h-100">
					<div class="card-header">
						Total Energy Usage
					</div>
					<div class="card-body">
						<h1 class="card-title">{{ totalConsumption }} MMBTU</h1>
						<h6 class="card-text">Across {{ samp_dat.length }} Buildings</h6>
						<a :href="`/buildings/`" class="btn btn-primary">See more info</a>
					</div>
				</div>
			</div>

			<div class="grid-item grid-item2">
				<Map></Map>
			</div>
			<div v-if="highestUse" class="grid-item highestUser">
				<div class="card w-100 border-danger summary">
					<div class="card-header">
						Highest Energy Usage
					</div>
					<div class="card-body">
						<h5 class="card-title">{{ highestUse.buildingName }}</h5>
						<h6 class="card-text text-danger">{{ highestUse.energyUsage }}</h6>
						<a :href="`/buildings/${highestUse.bbl}`" class="btn btn-primary">See more info</a>
					</div>
				</div>

			</div>

			<div v-if="lowestUse" class="grid-item grid-item5">
				<div class="card  w-100 summary border-success ">
					<div class="card-header">
						Lowest Energy Usage
					</div>
					<div class="card-body">
						<h5 class="card-title">{{ lowestUse.buildingName }}</h5>
						<h6 class="card-text text-success">{{ lowestUse.energyUsage }}</h6>
						<a :href="`/buildings/${lowestUse.bbl}`" class="btn btn-primary">See more info</a>
					</div>
				</div>
			</div>

			<div v-if="averageConsumption" class="grid-item grid-item5">
				<div class="card  w-100 summary border-success h-100 ">
					<div class="card-header">
						Average Energy Usage
					</div>
					<div class="card-body">
						<h5 class="card-title">{{ averageConsumption }}</h5>
						<h6 class="card-text text-success">Per building</h6>
					</div>
				</div>
			</div>
			<div class="grid-item grid-item7">

			</div>
		</div>
	</div>
</template>


<style>
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
	/* border-style: solid; */
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