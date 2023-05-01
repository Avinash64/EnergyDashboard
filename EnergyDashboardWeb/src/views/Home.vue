<script setup>
import BarChart from "./BarChart.vue";
import Map from "./Map.vue";
import { ref, onMounted, computed, watch } from 'vue';
const b_num = ref('0')

const samp_dat = ref([])
const highestUse = ref(null)
const lowestUse = ref(null)
onMounted(() => {
	const options = {
		method: 'GET',
		headers: {}
	};


	fetch('http://localhost:5156/api/energy', options)
		.then(response => response.json())
		.then(response => {
			console.log(response); samp_dat.value = response
			highestUse.value = samp_dat.value.reduce(function (prev, current) {
				return (prev.energyUsage > current.energyUsage) ? prev : current
			})

			lowestUse.value = samp_dat.value.reduce(function (prev, current) {
				return (prev.energyUsage < current.energyUsage) ? prev : current
			})
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
			<div class="grid-item grid-item3">Grid </div>
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