using StudentManagementSystem.Application.DTOS;

public interface ITrainerService
{
    Task<List<StudentDto>> GetAssignedStudents(Guid trainerId);
    Task<TrainerStatsDto> GetTrainerStats(Guid trainerId);
    Task UpdateStudentProgress(Guid studentId, int progress);
    Task AddFeedback(Guid trainerId, FeedbackDto dto);
    // ✅ STUDY MATERIALS
    Task<List<StudyMaterialDto>> GetMaterials(Guid trainerId);
    Task AddStudyMaterial(StudyMaterialDto dto, Guid trainerId);
    Task UpdateStudyMaterial(Guid materialId, StudyMaterialDto dto, Guid trainerId);
    Task DeleteStudyMaterial(Guid materialId, Guid trainerId);
}