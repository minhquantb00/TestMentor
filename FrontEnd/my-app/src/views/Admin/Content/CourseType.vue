<template>
  <div class="course-type">
    <div class="btn-add-course text-right">
      <v-dialog persistent max-width="600">
        <template v-slot:activator="{ props: activatorProps }">
          <v-btn
            color="purple-accent-4"
            size="small"
            variant="flat"
            text="Thêm mới"
            v-bind="activatorProps"
            class="mb-6"
          >
          </v-btn>
        </template>

        <template v-slot:default="{ isActive }">
          <div>
            <v-card class="pa-5">
              <label>
                <span class="obligatory mr-2">*</span>
                Tên thể loại khóa học
              </label>
              <v-text-field
                class="mt-3"
                :rules="rules"
                v-model="inputCreateCourseTypes.tenLoaiKhoaHoc"
                color="purple-accent-4"
                variant="outlined"
                placeholder="Tên thể loại khóa học"
              ></v-text-field>
              <v-card-actions>
                <v-spacer></v-spacer>

                <v-btn
                  :disabled="loading"
                  :loading="loading"
                  class="text-none mt-4"
                  color="purple-accent-4"
                  size="x-large"
                  variant="flat"
                  @click="createCourseType"
                  >Thêm thể loại khóa học</v-btn
                >
                <v-btn
                  class="text-none mt-4"
                  color="#000"
                  size="x-large"
                  variant="outlined"
                  @click="isActive.value = false"
                  >Hủy</v-btn
                >
              </v-card-actions>
            </v-card>
          </div>
        </template>
      </v-dialog>
    </div>
    <v-table height="300px" fixed-header>
      <thead>
        <tr>
          <th class="text-left">Tên thể loại</th>
          <th class="text-left">Thao tác</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in listCourseTypes" :key="item">
          <td>{{ item.tenLoaiKhoaHoc }}</td>
          <td>
            <router-link to="#">
              <v-btn
                icon
                class="mr-3 btn-update"
                @click="handleClickCourseId(n.id)"
                variant="text"
              >
                <font-awesome-icon icon="fa-solid fa-pen"></font-awesome-icon>
                <v-dialog persistent activator="parent" max-width="1000">
                  <template v-slot:default="{ isActive }">
                    <v-card class="pa-5">
                      <input v-model="khoaHocId" type="hidden" />
                      <label>
                        <span class="obligatory mr-2">*</span>
                        Tên loại khóa học
                      </label>
                      <v-text-field
                        class="mt-3"
                        :rules="rules"
                        v-model="tenLoaiKhoaHoc"
                        color="purple-accent-4"
                        variant="outlined"
                        placeholder="Tên loại khóa học"
                      ></v-text-field>

                      <v-btn
                        class="text-none mt-4"
                        color="#9933FF"
                        variant="flat"
                        size="x-large"
                        style="color: #ffffff"
                        :loading="loading"
                        @click="updateCourse"
                        >Sửa bài học</v-btn
                      >
                      <v-btn
                        class="text-none mt-4"
                        color="black"
                        variant="outlined"
                        size="x-large"
                        style="color: #000"
                        @click="isActive.value = false"
                      >
                        Hủy
                      </v-btn>
                    </v-card>
                  </template>
                </v-dialog>
              </v-btn>
            </router-link>
            <router-link to="#">
              <v-btn icon class="btn-delete" @click="deleteCoure(n.id)" variant="text">
                <font-awesome-icon
                  icon="fa-regular fa-trash-can"
                ></font-awesome-icon>
              </v-btn>
            </router-link>
          </td>
        </tr>
      </tbody>
    </v-table>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>
<script>
import { courseTypeApi } from "../../../apis/Course/courseTypeApi";

export default {
  data() {
    return {
      courseTypeApiInstance: courseTypeApi(),
      listCourseTypes: [],
      inputCreateCourseTypes: {
        tenLoaiKhoaHoc: "",
      },
      text: "",
      snackbar: false,
      columns: [],
      state: [
        {
          searchText: "",
          searchedColumn: "",
        },
      ],
    };
  },
  async mounted() {
    try {
      const res = await this.courseTypeApiInstance.getAllCoursesType();
      console.log(res);
      this.listCourseTypes = res;
    } catch (e) {
      console.error("Error Fetching failed: " + e.message);
    }
  },
  methods: {
    handleSearch(selectedKeys, confirm, dataIndex) {
      confirm();
      state.searchText = selectedKeys[0];
      state.searchedColumn = dataIndex;
    },
    handleReset(clearFilters) {
      clearFilters({
        confirm: true,
      });
      state.searchText = "";
    },
    async createCourseType() {
      const result = await this.courseTypeApiInstance.createCourseTypes(
        this.inputCreateCourseTypes
      );
      if (result) {
        this.text = "Thêm loại khóa học thành công";
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      } else {
        this.text = "Thêm thể loại khóa học thất bại";
        this.snackbar = true;
      }
    },
    reloadPage() {
      location.reload();
    },
  },
};
</script>

<style scoped>
.obligatory {
  color: red;
}
.highlight {
  background-color: rgb(255, 192, 105);
  padding: 0px;
}
.btn-update {
  color: black;
}
.btn-update:hover {
  color: rgb(255, 234, 0);
}
.btn-delete {
  color: black;
}
.btn-delete:hover {
  color: red;
}
</style>
